using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Descending.World
{
    public abstract class Feature : MonoBehaviour
    {
        [SerializeField] private FeatureDefinition _definition = null;

        private int _threatLevel = 0;
        
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
    }
}
