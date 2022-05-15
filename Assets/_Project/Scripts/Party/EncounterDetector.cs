using System.Collections;
using System.Collections.Generic;
using Descending.Encounters;
using ScriptableObjectArchitecture;
using UnityEngine;

namespace Descending.Party
{
    public class EncounterDetector : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
         {
             if (other.CompareTag("Encounter"))
             {
                 Encounter encounter = other.GetComponentInParent<Encounter>();
                 encounter.Trigger();
             }
        }
    }
}
