using System.Collections;
using System.Collections.Generic;
using Descending.Core;
using UnityEngine;

namespace Descending.Encounters
{
    public static class EncounterGenerator
    {
        private static List<List<string>> _enemyGroupLists = null;

        public static void Setup()
        {
            _enemyGroupLists = new List<List<string>>();
            
            for (int i = 0; i < (int)EnemyGroups.Number; i++)
            {
                _enemyGroupLists.Add(new List<string>());
            }
            
            foreach (var enemyKvp in Database.instance.Enemies.Dictionary)
            {
                _enemyGroupLists[(int)enemyKvp.Value.Group].Add(enemyKvp.Key);
            }
        }
        
        public static void BuildEncounter(Encounter encounter)
        {
            EncounterDifficulties difficulty = (EncounterDifficulties) Random.Range(0, (int) EncounterDifficulties.Number);
            EnemyGroups group = (EnemyGroups) Random.Range(0, (int) EnemyGroups.Number);
            List<EnemyShort> enemies = new List<EnemyShort>();

            int numEnemies = Random.Range(1, 7);
            
            for (int i = 0; i < numEnemies; i++)
            {
                int rndIndex = Random.Range(0, _enemyGroupLists[(int) group].Count);
                string enemyKey = _enemyGroupLists[(int) group][rndIndex];
                enemies.Add(new EnemyShort(enemyKey, 1));
            }

            encounter.SetupData(difficulty, group, enemies);
        }
    }
}
