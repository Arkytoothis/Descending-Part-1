using System.Collections;
using System.Collections.Generic;
using System.IO;
using Descending.Characters;
using Descending.Core;
using Sirenix.Serialization;
using UnityEngine;

namespace Descending.Party
{
    [System.Serializable]
    public class PartyData
    {
        [SerializeField] private List<Hero> _heroes = null;
        
        public List<Hero> Heroes => _heroes;

        public PartyData()
        {
            _heroes = new List<Hero>();
        }

        public PartyData(List<Hero> heroes)
        {
            _heroes = new List<Hero>();
            for (int i = 0; i < heroes.Count; i++)
            {
                _heroes.Add(heroes[i]);
            }
        }

        public void AddHero(Hero hero, Transform parent)
        {
            _heroes.Add(hero);
            hero.transform.SetParent(parent, false);
        }

        public void SavePartyData()
        {
            List<HeroSaveData> saveData = new List<HeroSaveData>();
            for (int i = 0; i < _heroes.Count; i++)
            {
                HeroSaveData data = new HeroSaveData(_heroes[i]);
                saveData.Add(data);
            }
            
            byte[] bytes = SerializationUtility.SerializeValue(saveData, DataFormat.JSON);
            File.WriteAllBytes(Database.instance.PartyDataFilePath, bytes);
        }
    }
}
