using System.Collections;
using System.Collections.Generic;
using Descending.Attributes;
using Descending.Core;
using Pathfinding;
using Pathfinding.RVO;
using UnityEngine;

namespace Descending.Characters
{
    public static class HeroBuilder
    {
        public static Hero BuildHero(Genders gender, RaceDefinition race, ProfessionDefinition profession, bool pathingEnabled, bool equipWeapons, int listIndex, bool enableInfoBar, bool enablePortrait)
        {
            GameObject clone = GameObject.Instantiate(Database.instance.HeroPrefab, null);

            Hero hero = clone.GetComponent<Hero>();
            if (pathingEnabled == false)
            {
                //hero.GetComponent<RVOController>().enabled = false;
                //hero.GetComponent<RichAI>().enabled = false;
                //hero.GetComponent<Seeker>().enabled = false;
                // GameObject.Destroy(hero.GetComponent<RVOController>());
                // GameObject.Destroy(hero.GetComponent<RichAI>());
                // GameObject.Destroy(hero.GetComponent<Seeker>());
            }
            
            hero.Setup(gender, race, profession, equipWeapons, listIndex, enableInfoBar, enablePortrait);
            
            return hero;
        }
        public static Hero LoadHero(HeroSaveData saveData, bool pathingEnabled, bool equipWeapons, bool enablePortrait)
        {
            GameObject clone = GameObject.Instantiate(Database.instance.HeroPrefab, null);

            Hero hero = clone.GetComponent<Hero>();

            if (pathingEnabled == false)
            {
                //hero.GetComponent<RVOController>().enabled = false;
                //hero.GetComponent<RichAI>().enabled = false;
                //hero.GetComponent<Seeker>().enabled = false;
                // GameObject.Destroy(hero.GetComponent<RVOController>());
                // GameObject.Destroy(hero.GetComponent<RichAI>());
                // GameObject.Destroy(hero.GetComponent<Seeker>());
            }
            
            hero.Load(saveData, equipWeapons, enablePortrait);
            
            return hero;
        }

        public static GameObject SpawnWorldPrefab(Genders gender, RaceDefinition race, Transform parent)
        {
            if (gender == Genders.Male) return GameObject.Instantiate(race.PrefabMale, parent);
            else if (gender == Genders.Female) return GameObject.Instantiate(race.PrefabFemale, parent);
            else return null;
        }
        

        public static GameObject SpawnPortraitPrefab(Genders gender, RaceDefinition race, Transform parent)
        {
            if (gender == Genders.Male) return GameObject.Instantiate(race.PrefabMale, parent);
            else if (gender == Genders.Female) return GameObject.Instantiate(race.PrefabFemale, parent);
            else return null;
        }
    }
}
