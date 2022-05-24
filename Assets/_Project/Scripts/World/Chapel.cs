using System.Collections;
using System.Collections.Generic;
using ScriptableObjectArchitecture;
using UnityEngine;

namespace Descending.World
{
    public class Chapel : Feature
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

        public void EndInteraction()
        {
            _interacting = false;
        }

        public override void Highlight()
        {
            
        }

        public override void Unhighlight()
        {
            
        }
    }
}
