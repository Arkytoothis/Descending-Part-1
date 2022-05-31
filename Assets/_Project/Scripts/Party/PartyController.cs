using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Cinemachine;
using Descending.Characters;
using Descending.Combat;
using Descending.Core;
using Pathfinding;
using ScriptableObjectArchitecture;
using Sirenix.Serialization;
using UnityEngine;

namespace Descending.Party  
{
    public class PartyController : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera _camera = null;
        [SerializeField] private ResourcesController _resources = null;
        [SerializeField] private Transform _heroesParent = null;
        [SerializeField] private AIPath _pathAi = null;
        [SerializeField] private PartyMover _partyMover = null;
        [SerializeField] private PartyData _partyData = null;
        [SerializeField] private WorldRaycaster _worldRaycaster = null;
        [SerializeField] private CombatRaycaster _combatRaycaster = null;

        [SerializeField] private PartyControllerEvent onSyncParty = null;
        public PartyData PartyData => _partyData;

        public void Setup()
        {
            //Debug.Log("PartyController.Setup");
            _partyData = new PartyData();
            _resources.AddCoins(100);
            _resources.AddGems(0);
            _resources.AddMaterials(0);
            _resources.AddSupplies(10);

            _partyData.AddHero(HeroBuilder.BuildHero(Utilities.GetRandomGender(), Database.instance.Races.GetRace("Half Orc"), Database.instance.Profession.GetProfession("Soldier"), true, true, 0, false, true), _heroesParent);
            _partyData.AddHero(HeroBuilder.BuildHero(Utilities.GetRandomGender(), Database.instance.Races.GetRace("Wild Elf"), Database.instance.Profession.GetProfession("Scout"), true, true, 1, false, true), _heroesParent);
            _partyData.AddHero(HeroBuilder.BuildHero(Utilities.GetRandomGender(), Database.instance.Races.GetRace("Mountain Dwarf"), Database.instance.Profession.GetProfession("Acolyte"), true, true, 2, false, true), _heroesParent);
            _partyData.AddHero(HeroBuilder.BuildHero(Utilities.GetRandomGender(), Database.instance.Races.GetRace("Valarian"), Database.instance.Profession.GetProfession("Apprentice"), true, true, 3, false, true), _heroesParent);
            
            _partyMover.SetPathingTargets();
            SetLeader(0);

            _worldRaycaster.enabled = true;
            _combatRaycaster.enabled = false;
        }

        public void Load()
        {
            _partyData = new PartyData();
	
            LoadResources();
            LoadParty();
            SetLeader(0);

            _worldRaycaster.enabled = true;
            _combatRaycaster.enabled = false;
        }

        private void LoadResources()
        {
            if (!File.Exists(Database.instance.ResourceDataFilePath)) return;
            
            byte[] bytes = File.ReadAllBytes(Database.instance.ResourceDataFilePath);
            var saveData = SerializationUtility.DeserializeValue<ResourceSaveData>(bytes, DataFormat.Binary);

            _resources.AddCoins(saveData.Coins);
            _resources.AddGems(saveData.Gems);
            _resources.AddMaterials(saveData.Materials);
            _resources.AddSupplies(saveData.Supplies);
        }

        private void LoadParty()
        {
            if (!File.Exists(Database.instance.PartyDataFilePath)) return;

            byte[] bytes = File.ReadAllBytes(Database.instance.PartyDataFilePath);
            List<HeroSaveData> saveData = SerializationUtility.DeserializeValue<List<HeroSaveData>>(bytes, DataFormat.JSON);

            for (int i = 0; i < saveData.Count; i++)
            {
                _partyData.AddHero(HeroBuilder.LoadHero(saveData[i], true, true, false, true), _heroesParent);
            }
            
        }

        public void Select()
        {
            SyncParty();
            SetCameraTarget(0);
        }

        public void SyncParty()
        {
            //Debug.Log("Syncing Party");
            onSyncParty.Invoke(this);
        }

        public void CombatStarted(CombatParameters parameters)
        {
            _pathAi.canMove = false;
            _pathAi.canSearch = false;
            _worldRaycaster.enabled = false;
            _combatRaycaster.enabled = true;
        }
        
        public void OnCombatEnded(bool b)
        {
            _pathAi.canMove = true;
            _pathAi.canSearch = true;
            _worldRaycaster.enabled = true;
            _combatRaycaster.enabled = false;

            for (int i = 0; i < _partyData.Heroes.Count; i++)
            {
                _partyData.Heroes[i].EndCombat();
            }
        }

        public void OnAddExperience(int experience)
        {
            for (int i = 0; i < _partyData.Heroes.Count; i++)
            {
                _partyData.Heroes[i].AddExperience(experience);
            }
        }

        public void Save()
        {
            _resources.Save();
        }

        public void SetCameraTarget(int index)
        {
            _camera.m_Follow = _partyData.Heroes[index].transform;
            _camera.m_LookAt = _partyData.Heroes[index].transform;
        }

        public void SetLeader(int leaderIndex)
        {
            for (int i = 0; i < _partyData.Heroes.Count; i++)
            {
                if (i == leaderIndex)
                {
                    //_partyData.Heroes[i].SetInteractionDetectorActive(true);
                }
                else
                {
                    //_partyData.Heroes[i].SetInteractionDetectorActive(false);
                }
            }
        }

        public void TeleportTo(Vector3 teleportPosition)
        {
            transform.position = teleportPosition;
        }
    }
}
