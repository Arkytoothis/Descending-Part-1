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
            Debug.Log(other.name);
            if (other.gameObject.CompareTag("Encounter"))
            {
                Debug.Log("Encounter Detected");
                Encounter encounter = other.gameObject.GetComponentInParent<Encounter>();
                if (encounter != null)
                {
                    encounter.Trigger();
                }
            }
        }
    }
}
