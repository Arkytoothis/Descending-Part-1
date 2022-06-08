using System;
using System.Collections;
using System.Collections.Generic;
using ScriptableObjectArchitecture;
using UnityEngine;

namespace Descending.Dungeons
{
    public class PartySpawner : MonoBehaviour
    {
        [SerializeField] private GameObjectEvent onRegisterSpawner = null;
        
        private void Awake()
        {
            onRegisterSpawner.Invoke(gameObject);
        }

        public void SpawnParty(GameObject partyObject)
        {
            partyObject.transform.position = transform.position;
        }
    }
}