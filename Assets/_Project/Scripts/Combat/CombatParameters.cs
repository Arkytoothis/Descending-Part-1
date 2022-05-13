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
        public PartyController Party = null;
        public Encounter Encounter = null;

        public CombatParameters(PartyController party, Encounter encounter)
        {
            Party = party;
            Encounter = encounter;
        }
    }
}
