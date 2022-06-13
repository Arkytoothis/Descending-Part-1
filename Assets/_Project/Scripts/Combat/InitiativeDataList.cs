using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Descending.Combat
{
    [System.Serializable]
    public class InitiativeDataList
    {
        [SerializeField] private List<InitiativeData> _list = null;

        public List<InitiativeData> List => _list;

        public InitiativeDataList(List<InitiativeData> list)
        {
            _list = list;
        }
    }
}