using System.Collections;
using System.Collections.Generic;
using Descending.World;
using ScriptableObjectArchitecture;
using UnityEngine;

namespace Descending.Party
{
    public class TreasureDetector : MonoBehaviour
    {
        [SerializeField] private TreasureEvent onTreasureEncountered = null;
        
        private void OnTriggerEnter(Collider other)
        {
            // if (other.CompareTag("Treasure"))
            // {
            //     Treasure treasure = other.GetComponent<Treasure>();
            //     //_party.TreasurerEncountered(treasure);
            //     onTreasureEncountered.Invoke(treasure);
            // }
        }
    }
}
