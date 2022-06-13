using System.Collections;
using System.Collections.Generic;
using Descending.Encounters;
using Descending.Party;
using UnityEngine;

namespace Descending.Combat
{
    [System.Serializable]
    public class CombatParameters
    {
        [SerializeField] private PartyManager _partyManager = null;
        [SerializeField] private Encounter _encounter = null;

        public PartyManager PartyManager => _partyManager;
        public Encounter Encounter => _encounter;
        

        public CombatParameters(PartyManager partyManager, Encounter encounter)
        {
            _partyManager = partyManager;
            _encounter = encounter;
        }
    }
}