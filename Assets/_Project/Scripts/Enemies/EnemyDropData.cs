using System.Collections;
using System.Collections.Generic;
using Descending.Equipment;
using UnityEngine;

namespace Descending.Enemies
{
    [System.Serializable]
    public class EnemyDropData
    {
        [SerializeField] private ItemDefinition _item = null;
        [SerializeField] private int _minimumAmount = 0;
        [SerializeField] private int _maximumAmount = 0;

        public ItemDefinition Item => _item;
        public int MinimumAmount => _minimumAmount;
        public int MaximumAmount => _maximumAmount;

        public EnemyDropData(ItemDefinition item, int minimumAmount, int maximumAmount)
        {
            _item = item;
            _minimumAmount = minimumAmount;
            _maximumAmount = maximumAmount;
        }
    }
}
