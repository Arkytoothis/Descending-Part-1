using Descending.Core;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Descending.Equipment.Enchantments
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "Enchantment Definition", menuName = "Descending/Definition/Enchantment Definition")]
    public class EnchantmentDefinition : ScriptableObject
    {
        [SerializeField] private string _name = "";
        [SerializeField] private string _key = "";
        [SerializeField] private RarityDefinition _rarity = null;
        [SerializeField] private EnchantmentType _enchantmentType = EnchantmentType.None;
        [SerializeField] private EnchantmentUsability _usability = EnchantmentUsability.None;
        [SerializeField] private float _goldValue = 0;
        [SerializeField] private int _gemValue = 0;
        [SerializeField] private int _itemPower = 0;
        [SerializeField] private float _encumbranceModifier = 0f;

        [SerializeReference] private List<EnchantmentEffect> _effects = null;

        public string Name { get => _name; }
        public string Key { get => _key; }
        public RarityDefinition Rarity => _rarity;
        public EnchantmentType EnchantmentType { get => _enchantmentType; }
        public EnchantmentUsability Usability { get => _usability; }
        public List<EnchantmentEffect> Effects { get => _effects; }
        public float GoldValue { get => _goldValue; }
        public int GemValue { get => _gemValue; }
        public int ItemPower { get => _itemPower; }
        public float EncumbranceModifier { get => _encumbranceModifier; }
    }
}