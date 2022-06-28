using System.Collections;
using System.Collections.Generic;
using System.IO;
using Descending.Attributes;
using Descending.Characters;
using Descending.Core;
using Descending.Equipment;
using ScriptableObjectArchitecture;
using Sirenix.Serialization;
using UnityEngine;

namespace Descending.Party
{
    public class PartyManager : MonoBehaviour
    {
        [SerializeField] private GameObject _partyObject = null;
        [SerializeField] private PartySpawner _spawner = null;
        [SerializeField] private Transform _heroesParent = null;
        [SerializeField] private FirstPersonController _controller = null;
        [SerializeField] private ResourcesController _resources = null;
        [SerializeField] private StockpileController _stockpile = null;
        [SerializeField] private bool _loadData = true;
        
        [SerializeField] private PartyDataEvent onSyncPartyData = null;

        private PartyData _partyData = null;

        public PartyData PartyData => _partyData;
        public GameObject PartyObject => _partyObject;

        public void Setup()
        {
            _partyData = new PartyData();
            if (_loadData == false)
            {
                BuildParty();
            }
            else
            {
                LoadParty();
            }

            _controller.UseGravity = true;
        }

        private void BuildParty()
        {
            _partyData.AddHero(SpawnHero(0, Utilities.GetRandomGender(), Database.instance.Races.GetRace("Half Orc"), Database.instance.Profession.GetProfession("Soldier")), null);
            _partyData.AddHero(SpawnHero(1, Utilities.GetRandomGender(), Database.instance.Races.GetRace("Imperial"), Database.instance.Profession.GetProfession("Mercenary")), null);
            _partyData.AddHero(SpawnHero(2, Utilities.GetRandomGender(), Database.instance.Races.GetRace("Halfling"), Database.instance.Profession.GetProfession("Thief")), null);
            _partyData.AddHero(SpawnHero(3, Utilities.GetRandomGender(), Database.instance.Races.GetRace("Wild Elf"), Database.instance.Profession.GetProfession("Scout")), null);
            _partyData.AddHero(SpawnHero(4, Utilities.GetRandomGender(), Database.instance.Races.GetRace("Mountain Dwarf"), Database.instance.Profession.GetProfession("Acolyte")), null);
            _partyData.AddHero(SpawnHero(5, Utilities.GetRandomGender(), Database.instance.Races.GetRace("Valarian"), Database.instance.Profession.GetProfession("Apprentice")), null);

            _resources.AddCoins(100);
            _resources.AddSupplies(12);
            
            SyncPartyData();
        }

        private Hero SpawnHero(int index, Genders gender, RaceDefinition race, ProfessionDefinition profession)
        {
            Hero hero = HeroBuilder.BuildHero(gender, race, profession, index);

            return hero;
        }

        public void SyncPartyData()
        {
            onSyncPartyData.Invoke(_partyData);
        }

        public void OnRegisterSpawner(PartySpawner spawner)
        {
            _spawner = spawner;
            _spawner.SpawnParty(_partyObject);
        }

        public void OnAddExperience(int amount)
        {
            for (int i = 0; i < _partyData.Heroes.Count; i++)
            {
                _partyData.Heroes[i].AddExperience(amount);
            }

            SyncPartyData();
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
        }

        private void LoadParty()
        {
            //Debug.Log("Loading Party");
            if (!File.Exists(Database.instance.PartyDataFilePath)) return;

            byte[] bytes = File.ReadAllBytes(Database.instance.PartyDataFilePath);
            List<HeroSaveData> saveData = SerializationUtility.DeserializeValue<List<HeroSaveData>>(bytes, DataFormat.JSON);

            for (int i = 0; i < saveData.Count; i++)
            {
                _partyData.AddHero(HeroBuilder.LoadHero(saveData[i]), _heroesParent);
            }

            _resources.AddCoins(100);
            _resources.AddSupplies(12);
            _resources.AddMaterials(0);
            _resources.AddGems(0);
            

            for (int i = 0; i < 20; i++)
            {
                Item item = ItemGenerator.GenerateRandomItem(Database.instance.Rarities.GetRarity("Legendary"), 10, 10, 10);
                _stockpile.PickupItem(item);
            }            

            _stockpile.SyncStockpile();
        }

        public void SetSpawnerPosition(Vector3 position)
        {
            _spawner.transform.position = position;
        }
    }
}