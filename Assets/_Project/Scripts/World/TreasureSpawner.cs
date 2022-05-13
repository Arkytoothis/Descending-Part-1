using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Descending.World
{
    public class TreasureSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject _treasurePrefab = null;
        [SerializeField] private int _spawnChance = 100;
        [SerializeField] private int _threatLevel = 1;

        public void Awake()
        {
            //Debug.Log("EncounterSpawner.Awake");
            if (Random.Range(0, 100) < _spawnChance)
            {
                GameObject clone = Instantiate(_treasurePrefab, transform);
                Treasure treasure = clone.GetComponent<Treasure>();
                treasure.SetParentOnSpawn(false);
                treasure.GenerateTreasure(_threatLevel);
            }
        }
    }
}
