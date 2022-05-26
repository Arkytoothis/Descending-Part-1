using System;
using System.Collections;
using System.Collections.Generic;
using Descending.Attributes;
using Descending.Characters;
using Descending.Core;
using UnityEngine;

namespace Descending.Scene_MainMenu
{
    public class PartyManager : MonoBehaviour
    {
        [SerializeField] private List<Transform> _partyMounts = null;

        private List<Hero> _heroes = null;

        public List<Hero> Heroes => _heroes;

        public void Setup()
        {
            _heroes = new List<Hero>();
        }

        public void GenerateParty()
        {
            _heroes.Clear();
            
            SpawnHero(0, Utilities.GetRandomGender(), Utilities.GetRandomRace(), Database.instance.Profession.GetProfession("Soldier"));  
            SpawnHero(1, Utilities.GetRandomGender(), Utilities.GetRandomRace(), Database.instance.Profession.GetProfession("Mercenary")); 
            SpawnHero(2, Utilities.GetRandomGender(), Utilities.GetRandomRace(), Database.instance.Profession.GetProfession("Thief")); 
            SpawnHero(3, Utilities.GetRandomGender(), Utilities.GetRandomRace(), Database.instance.Profession.GetProfession("Scout")); 
            SpawnHero(4, Utilities.GetRandomGender(), Utilities.GetRandomRace(), Database.instance.Profession.GetProfession("Acolyte")); 
            SpawnHero(5, Utilities.GetRandomGender(), Utilities.GetRandomRace(), Database.instance.Profession.GetProfession("Apprentice"));   
        }

        private void SpawnHero(int index, Genders gender, RaceDefinition race, ProfessionDefinition profession)
        {
            _partyMounts[index].ClearTransform();
                
            Hero hero = HeroBuilder.BuildHero(gender, race, profession, false, true, index, false, false);
            hero.transform.SetParent(_partyMounts[index], false);
            _heroes.Add(hero);
        }
    } 
}