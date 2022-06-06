using System;
using System.Collections;
using System.Collections.Generic;
using Descending.Encounters;
using Descending.World;
using UnityEngine;

namespace Descending.Party
{
    public class InteractionDetector : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Feature Interaction"))
            {
                Feature feature = other.gameObject.GetComponentInParent<Feature>();
                feature.Interact();
            }
        }
    }
}
