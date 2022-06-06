using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Descending.Abilities
{
    [System.Serializable]
    public class AbilityTreeEntry
    {
        [SerializeField] private AbilityDefinition _ability = null;
        [SerializeField] private int _pointsRequired = 0;
    }
}