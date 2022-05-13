using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Descending.Characters;
using Descending.Combat;
using Descending.Core;
using ScriptableObjectArchitecture;
using Sirenix.Serialization;
using UnityEngine;

namespace Descending.Party  
{
    public class PartyController : MonoBehaviour
    {
        [SerializeField] private ResourcesController _resources = null;
        [SerializeField] private PartyFormation _formation = null;
        [SerializeField] private Transform _heroesParent = null;
        [SerializeField] private float _visionRadius = 20f;
        [SerializeField] private float _fogOffset = -10f;
        [SerializeField] private float _fogRevealDelay = 0.1f;
        
        [SerializeField] private PartyControllerEvent onSyncParty = null;
        
        [SerializeField] private PartyData _partyData = null;
        //[SerializeField] private VolumetricFog _fogOfWar = null;

        public PartyData PartyData => _partyData;
        public PartyFormation Formation => _formation;

        public void Setup()
        {
            //Debug.Log("PartyController.Setup");
            _partyData = new PartyData();
            _resources.AddCoins(100);
            _resources.AddGems(0);
            _resources.AddSupplies(10);

            _partyData.AddHero(HeroBuilder.BuildHero(Utilities.GetRandomGender(), Database.instance.Races.GetRace("Imperial"), Database.instance.Profession.GetProfession("Soldier"), true, true, 0, true), _heroesParent);
            _partyData.AddHero(HeroBuilder.BuildHero(Utilities.GetRandomGender(), Database.instance.Races.GetRace("Halfling"), Database.instance.Profession.GetProfession("Thief"), true, true, 1, true), _heroesParent);
            _partyData.AddHero(HeroBuilder.BuildHero(Utilities.GetRandomGender(), Database.instance.Races.GetRace("Islander"), Database.instance.Profession.GetProfession("Acolyte"), true, true, 2, true), _heroesParent);
            _partyData.AddHero(HeroBuilder.BuildHero(Utilities.GetRandomGender(), Database.instance.Races.GetRace("Valarian"), Database.instance.Profession.GetProfession("Apprentice"), true, true, 3, true), _heroesParent); 
        }

        public void Load()
        {
            _partyData = new PartyData();
	
            LoadResources();
            LoadParty();
        }

        private void LoadResources()
        {
            if (!File.Exists(Database.instance.ResourceDataFilePath)) return;
            
            byte[] bytes = File.ReadAllBytes(Database.instance.ResourceDataFilePath);
            var saveData = SerializationUtility.DeserializeValue<ResourceSaveData>(bytes, DataFormat.Binary);

            _resources.AddCoins(saveData.Coins);
            _resources.AddGems(saveData.Gems);
            _resources.AddSupplies(saveData.Supplies);
        }

        private void LoadParty()
        {
            if (!File.Exists(Database.instance.PartyDataFilePath)) return;

            byte[] bytes = File.ReadAllBytes(Database.instance.PartyDataFilePath);
            List<HeroSaveData> saveData = SerializationUtility.DeserializeValue<List<HeroSaveData>>(bytes, DataFormat.JSON);

            for (int i = 0; i < saveData.Count; i++)
            {
                _partyData.AddHero(HeroBuilder.LoadHero(saveData[i], true, true), _heroesParent);
            }
        }

        private void SetFormation()
        {
            for (int i = 0; i < _partyData.Heroes.Count; i++)
            {
                _partyData.Heroes[i].transform.localPosition = _formation.Positions[i].position;
            }
        }

        public void MoveToFormation()
        {
            for (int i = 0; i < _partyData.Heroes.Count; i++)
            {
                _partyData.Heroes[i].Pathfinder.EnablePathing();
                _partyData.Heroes[i].Pathfinder.SetDestination(_formation.Positions[i].position);
            }
        }
        
        public void SetPosition(Vector3 position)
        {
            _formation.MoveTo(_partyData.Heroes[0].transform.position, position);
            SetFormation();
        }

        public void Select()
        {
            SyncParty();
        }

        public void SyncParty()
        {
            //Debug.Log("Syncing Party");
            onSyncParty.Invoke(this);
        }

        public void CombatStarted(CombatParameters parameters)
        {
        }
        
        public void OnCombatEnded(bool b)
        {
            for (int i = 0; i < _partyData.Heroes.Count; i++)
            {
                //_partyData.Heroes[i].BehaviorController.SetBehaviorActive(false);
            }
            
            _formation.SetFlagActive(true);
            MoveToFormation();
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
    }
}
