using System;
using System.Collections;
using System.Collections.Generic;
using Descending.Party;
using ScriptableObjectArchitecture;
using UnityEngine;

namespace Descending.World
{
    public class WorldSpawner : MonoBehaviour
    {
        [SerializeField] private WorldSpawnerEvent onRegisterSpawner = null;
        [SerializeField] private int _threatLevel = 0;

        public int ThreatLevel => _threatLevel;

        private void Awake()
        {
            onRegisterSpawner.Invoke(this);
        }

        public void SpawnParty(PartyManager partyManager)
        {
            partyManager.PartyObject.transform.position = transform.position;
        }

        public void Spawn(GameObject prefab, Transform parent)
        {
            GameObject clone = Instantiate(prefab, parent);
            clone.transform.position = transform.position;
        }

        public void Setup(Vector3 partyPosition, float threatModifier)
        {
            float distance = Vector3.Distance(transform.position, partyPosition);
            _threatLevel = (int)(distance / threatModifier);
        }
    }
}
