using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Descending.World
{
    public enum WorldSpawnerTypes
    {
        Encounter, Treasure, Dialog, 
        Number, None
    }
    public class WorldSpawner : MonoBehaviour
    {
        [SerializeField] private int _encounterChance = 50;
        [SerializeField] private int _treasureChance = 30;
        [SerializeField] private int _dialogChance = 20;
        [SerializeField] private List<GameObject> _prefabs = null;

        private void Start()
        {
            Generate();
        }

        public void Generate()
        {
            int roll = Random.Range(0, 100);
            {
                if (roll < _encounterChance)
                {
                    GameObject clone = Instantiate(_prefabs[(int) WorldSpawnerTypes.Encounter], null);
                    clone.transform.position = transform.position;
                }
                else if (roll < _encounterChance + _treasureChance)
                {
                    GameObject clone = Instantiate(_prefabs[(int) WorldSpawnerTypes.Treasure], null);
                    clone.transform.position = transform.position;
                }
                else if(roll <= _encounterChance + _treasureChance + _dialogChance)
                {
                    GameObject clone = Instantiate(_prefabs[(int) WorldSpawnerTypes.Dialog], null);
                    clone.transform.position = transform.position;
                }
            }
            
            Destroy(gameObject);
        }
    }
}
