using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Descending.World
{
    public abstract class Feature : MonoBehaviour
    {
        [SerializeField] private FeatureDefinition _definition = null;
        [SerializeField] private Transform _interactionTransform = null;

        private int _threatLevel = 0;
        protected bool _interacting = false;
        
        public Transform InteractionTransform => _interactionTransform;
        public int ThreatLevel => _threatLevel;
        public bool Interacting => _interacting;

        public void Setup()
        {
        }

        public void SetThreatLevel(int threatLevel)
        {
            _threatLevel = threatLevel;
            if (_threatLevel < 1)
                _threatLevel = 1;
            
            //Debug.Log("Threat: " + _threatLevel);
        }
        
        public FeatureDefinition Definition => _definition;

        public abstract void Interact();
        public abstract void Highlight();
        public abstract void Unhighlight();

        public void SetInteracting(bool interacting)
        {
            _interacting = interacting;
        }
    }
}
