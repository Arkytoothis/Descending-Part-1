using Descending.Core;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Descending.Equipment
{
    [System.Serializable]
    public class WearableData
    {
        [SerializeField] private bool _hasData = true;
        [SerializeField] private int _armor = 0;
        [SerializeField] private int _block = 0;
        [SerializeField] private int _spellDefense = 0;
        [SerializeField] private int _perceptionModifier = 0;

        [SerializeField] private WearableType _wearableType = WearableType.None;
        [SerializeField] private HeadCoverType _headCoverType = HeadCoverType.None;

        public bool HasData { get => _hasData; }
        public int Armor { get => _armor; }
        public int Block { get => _block; }
        public int SpellDefense { get => _spellDefense; }
        public int PerceptionModifier { get => _perceptionModifier; }

        public WearableType WearableType { get => _wearableType; }
        public HeadCoverType HeadCoverType { get => _headCoverType; }

        public WearableData(WearableData wearableData)
        {
            _hasData = wearableData._hasData;
            _armor = wearableData._armor;
            _block = wearableData._block;
            _spellDefense = wearableData._spellDefense;
            _perceptionModifier = wearableData._perceptionModifier;
            _wearableType = wearableData._wearableType;
            _headCoverType = wearableData._headCoverType;
        }

        public string GetTooltipText()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Armor: ");
            sb.Append(_armor);
            sb.Append("\n");

            sb.Append("Block: ");
            sb.Append(_block);
            sb.Append("\n");

            sb.Append("Spell Defense: ");
            sb.Append(_spellDefense);
            sb.Append("\n");

            sb.Append("Perception Modfier: ");
            sb.Append(_perceptionModifier);
            sb.Append("\n");

            return sb.ToString();
        }
    }
}