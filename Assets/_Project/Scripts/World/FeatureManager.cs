using System;
using System.Collections;
using System.Collections.Generic;
using Descending.Party;
using UnityEngine;

namespace Descending.World
{
    public class FeatureManager : MonoBehaviour
    {
        [SerializeField] private Transform _featureSpawnersParent = null;
        [SerializeField] private Transform _featuresParent = null;
        [SerializeField] private List<FeatureSpawner> _spawners = null;
        [SerializeField] private List<Feature> _features = null;

        private void Awake()
        {
            _spawners = new List<FeatureSpawner>();
            _features = new List<Feature>();
        }

        public void Setup(PartyController party, ref Vector3 startPosition, float threatModifier)
        {
            SpawnFeatures(party, ref startPosition, threatModifier);
        }

        private void SpawnFeatures(PartyController party, ref Vector3 startPosition, float threatModifier)
        {
            _spawners.Sort((u1, u2) => u1.transform.position.y.CompareTo(u2.transform.position.y));
            
            _spawners[0].Spawn("Imperial Village", _featuresParent);
            startPosition = _spawners[0].transform.position;
            party.SetPosition(_spawners[0].transform.position);
            _spawners.RemoveAt(0);
            
            for (int i = 0; i < _spawners.Count; i++)
            {
                _features.Add(_spawners[i].Spawn("Dungeon Entrance", _featuresParent));
            }
            
            SetThreatLevels(startPosition, threatModifier);
        }

        private void SetThreatLevels(Vector3 startPosition, float threatModifier)
        {
            for (int i = 0; i < _features.Count; i++)
            {
                float distance = Vector3.Distance(_features[i].transform.position, startPosition);
                //_features[i].SetThreatLevel((int)(distance / _threatLevelModifier));
                _features[i].SetThreatLevel((int)(distance / threatModifier));
            }    
        }
        
        public void RegisterSpawner(FeatureSpawnParameters parameters)
        {
            _spawners.Add(parameters.Spawner);
            parameters.Spawner.transform.SetParent(_featureSpawnersParent);
        }
        
        public void OnEnable ()
        {
            //TerrainTile.OnAllComplete -= OnMapFinished;
            //TerrainTile.OnAllComplete += OnMapFinished;
        }

        public void OnDisable ()
        {
            //TerrainTile.OnAllComplete -= OnMapFinished;
        }

        // private void OnMapFinished(MapMagicObject obj)
        // {
        //     Debug.Log("Map Finished");
        //     //SpawnFeatures();
        // }
    }
}
