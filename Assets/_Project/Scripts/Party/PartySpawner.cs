using System;
using System.Collections;
using System.Collections.Generic;
using ScriptableObjectArchitecture;
using UnityEngine;

namespace Descending.Party
{
    public class PartySpawner : MonoBehaviour
    {
        [SerializeField] private float _heightOffset = -0.5f;
        
        [SerializeField] private PartySpawnerEvent onRegisterSpawner = null;
        
        private void Awake()
        {
            onRegisterSpawner.Invoke(this);
        }

        public void SpawnParty(GameObject partyObject)
        {
            partyObject.transform.position = new Vector3(transform.position.x, transform.position.y + _heightOffset, transform.position.z);
        }
    }
}