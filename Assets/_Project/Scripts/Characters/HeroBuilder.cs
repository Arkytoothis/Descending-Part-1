using System.Collections;
using System.Collections.Generic;
using Descending.Attributes;
using Descending.Core;
using UnityEngine;

namespace Descending.Characters
{
    public static class HeroBuilder
    {
        public static Hero BuildHero(Genders gender, RaceDefinition race, ProfessionDefinition profession, int listIndex)
        {
            GameObject clone = GameObject.Instantiate(Database.instance.HeroPrefab, null);

            Hero hero = clone.GetComponent<Hero>();
            
            hero.Setup(gender, race, profession, listIndex);
            
            return hero;
        }
        
        public static Hero LoadHero(HeroSaveData saveData)
        {
            GameObject clone = GameObject.Instantiate(Database.instance.HeroPrefab, null);

            Hero hero = clone.GetComponent<Hero>();
            
            hero.Load(saveData);
            
            return hero;
        }
        
        public static GameObject SpawnPortraitPrefab(Genders gender, RaceDefinition race, Transform parent)
        {
            if (gender == Genders.Male) return GameObject.Instantiate(race.PrefabMale, parent);
            else if (gender == Genders.Female) return GameObject.Instantiate(race.PrefabFemale, parent);
            else return null;
        }
    }
}
