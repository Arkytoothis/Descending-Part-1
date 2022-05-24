using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Descending.World
{
    public class Village : Feature
    {
        public override void Interact()
        {
            Debug.Log("Interacting with " + Definition.Name);
        }

        public override void Highlight()
        {
            
        }

        public override void Unhighlight()
        {
            
        }
    }
}
