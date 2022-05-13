using System;
using System.Collections;
using System.Collections.Generic;
using ScriptableObjectArchitecture;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Descending.Encounters
{
    public class EncounterSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject _encounterPrefab = null;
        [SerializeField] private int _spawnChance = 100;

        public void Awake()
        {
            //Debug.Log("EncounterSpawner.Awake");
            if (Random.Range(0, 100) < _spawnChance)
            {
                GameObject clone = Instantiate(_encounterPrefab, transform);
                Encounter encounter = clone.GetComponent<Encounter>();
                encounter.SetParentOnSpawn(false);
            }
        }
    }
}
