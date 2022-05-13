using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Descending.Equipment
{
    [System.Serializable]
    public class ItemShort
    {
        [SerializeField] private string _itemKey = "";
        [SerializeField] private string _materialKey = "";
        [SerializeField] private string _qualityKey = "";
        [SerializeField] private string _prefixEnchantment = "";
        [SerializeField] private string _suffixEnchantment = "";

        public string ItemKey { get => _itemKey; }
        public string MaterialKey { get => _materialKey; }
        public string QualityKey { get => _qualityKey; }
        public string PrefixEnchantment { get => _prefixEnchantment; }
        public string SuffixEnchantment { get => _suffixEnchantment; }

        public ItemShort(string itemKey, string qualityKey, string materialKey = "", string prefix = "", string suffix = "")
        {
            _itemKey = itemKey;
            _materialKey = materialKey;
            _qualityKey = qualityKey;
            _prefixEnchantment = prefix;
            _suffixEnchantment = suffix;
        }
    }
}