using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Descending.World
{
    [System.Serializable]
    public class WorldGenerationData
    {
        [SerializeField] private int _worldSeed = 0;

        public int WorldSeed => _worldSeed;

        public WorldGenerationData(int worldSeed)
        {
            _worldSeed = worldSeed;
        }
    }
}