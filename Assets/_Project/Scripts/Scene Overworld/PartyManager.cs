using System.Collections;
using System.Collections.Generic;
using Descending.Attributes;
using Descending.Characters;
using Descending.Core;
using Descending.Party;
using ScriptableObjectArchitecture;
using UnityEngine;

namespace Descending.Scene_Overworld
{
    public class PartyManager : MonoBehaviour
    {
        [SerializeField] private GameObject _partyObject = null;
        [SerializeField] private PartySpawner _spawner = null;

        [SerializeField] private PartyDataEvent onSyncPartyData = null;

        private PartyData _partyData = null;

        public PartyData PartyData => _partyData;

        public void Setup()
        {
            _partyData = new PartyData();
            BuildParty();
        }

        private void BuildParty()
        {
            _partyData.AddHero(SpawnHero(0, Utilities.GetRandomGender(), Database.instance.Races.GetRace("Half Orc"), Database.instance.Profession.GetProfession("Soldier")), null);
            _partyData.AddHero(SpawnHero(1, Utilities.GetRandomGender(), Database.instance.Races.GetRace("Imperial"), Database.instance.Profession.GetProfession("Mercenary")), null);
            _partyData.AddHero(SpawnHero(2, Utilities.GetRandomGender(), Database.instance.Races.GetRace("Halfling"), Database.instance.Profession.GetProfession("Thief")), null);
            _partyData.AddHero(SpawnHero(3, Utilities.GetRandomGender(), Database.instance.Races.GetRace("Wild Elf"), Database.instance.Profession.GetProfession("Scout")), null);
            _partyData.AddHero(SpawnHero(4, Utilities.GetRandomGender(), Database.instance.Races.GetRace("Mountain Dwarf"), Database.instance.Profession.GetProfession("Acolyte")), null);
            _partyData.AddHero(SpawnHero(5, Utilities.GetRandomGender(), Database.instance.Races.GetRace("Valarian"), Database.instance.Profession.GetProfession("Apprentice")), null);

            _spawner.SpawnParty(_partyObject);
            SyncPartyData();
        }

        private Hero SpawnHero(int index, Genders gender, RaceDefinition race, ProfessionDefinition profession)
        {
            Hero hero = HeroBuilder.BuildHero(gender, race, profession, false, true, index, false, true);

            return hero;
        }

        public void SyncPartyData()
        {
            onSyncPartyData.Invoke(_partyData);
        }
    }
}