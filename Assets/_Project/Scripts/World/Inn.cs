using System.Collections;
using System.Collections.Generic;
using ScriptableObjectArchitecture;
using UnityEngine;

namespace Descending.World
{
    public class Inn : Feature
    {
        [SerializeField] private FeatureEvent onInteractWithFeature = null;
        
        public override void Interact()
        {
            if (_interacting == false)
            {
                //Debug.Log("Interacting with " + Definition.Name);
                _interacting = true;
                onInteractWithFeature.Invoke(this);
            }
        }

        public override void Highlight()
        {
            
        }

        public override void Unhighlight()
        {
            
        }

        public void EndInteraction()
        {
            _interacting = false;
        }
    }
}
