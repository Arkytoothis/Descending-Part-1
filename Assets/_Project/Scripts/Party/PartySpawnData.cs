using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Descending.World
{
    [System.Serializable]
    public class PartySpawnData
    {
        [SerializeField] private Vector3 _spawnPosition = Vector3.zero;

        public Vector3 SpawnPosition => _spawnPosition;

        public PartySpawnData(Vector3 spawnPosition)
        {
            _spawnPosition = spawnPosition;
        }
    }
}
