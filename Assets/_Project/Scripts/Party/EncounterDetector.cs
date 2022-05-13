using System.Collections;
using System.Collections.Generic;
using Descending.Encounters;
using ScriptableObjectArchitecture;
using UnityEngine;

namespace Descending.Party
{
    public class EncounterDetector : MonoBehaviour
    {
        //[SerializeField] private PartyController _party = null;

        [SerializeField] private EncounterEvent onEncounterEntered = null;
        
         private void OnTriggerEnter(Collider other)
         {
             if (other.CompareTag("Encounter"))
             {
                 Encounter encounter = other.GetComponent<Encounter>();
        
                 if (encounter.IsActive == true)
                 {
                     //_party.EncounterEntered(encounter);
                     //encounter.SetCombatCamPosition(_party.transform.position);
                     onEncounterEntered.Invoke(encounter);
                 }
             }
        }
    }
}
