using System;
using System.Collections;
using System.Collections.Generic;
using Descending.Encounters;
using UnityEngine;

namespace Descending.Party
{
    public class EncounterDetector : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Encounter"))
            {
                Encounter encounter = other.gameObject.GetComponentInParent<Encounter>();
                if (encounter != null)
                {
                    if(encounter.IsActive)
                        encounter.Trigger();
                }
            }
        }
    }
}
