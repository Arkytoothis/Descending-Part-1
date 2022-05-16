using System;
using System.Collections;
using System.Collections.Generic;
using ScriptableObjectArchitecture;
using UnityEngine;

namespace Descending.Dungeons
{
    public class PartySpawner : MonoBehaviour
    {
        [SerializeField] private Vector3Event onRegisterSpawnPosition = null;

        private void Start()
        {
            onRegisterSpawnPosition.Invoke(transform.position);
        }
    }
}