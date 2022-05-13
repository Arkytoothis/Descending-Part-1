using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Descending
{
    public class PartySpawner : MonoBehaviour
    {
        [SerializeField] private Transform _partyTransform = null;
        [SerializeField] private Transform _destinationTransform = null;

        private void Start()
        {
            _partyTransform.position = transform.position;
            _destinationTransform.position = transform.position;
        }
    }
}