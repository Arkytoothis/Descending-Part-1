using System.Collections;
using System.Collections.Generic;
using Descending.World;
using UnityEngine;

namespace Descending
{
    [System.Serializable]
    public class FeatureSpawnParameters
    {
        [SerializeField] private FeatureSpawner _spawner = null;

        public FeatureSpawner Spawner => _spawner;

        public FeatureSpawnParameters(FeatureSpawner spawner)
        {
            _spawner = spawner;
        }
    }
}
