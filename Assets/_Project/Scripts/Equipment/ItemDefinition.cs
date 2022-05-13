using Descending.Core;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Descending.Equipment
{
    [CreateAssetMenu(fileName = "Item Definition", menuName = "Descending/Definition/Item Definition")]
    public class ItemDefinition : ScriptableObject
    {
        [HorizontalGroup("Split", 150)]
        [PreviewField(38), BoxGroup("Split/Icon"), LabelWidth(75)]
        [SerializeField] private Sprite _icon = null;

        [SerializeField, BoxGroup("Split/Text"), LabelWidth(75)] private string _name = "New Item";
        [SerializeField, BoxGroup("Split/Text"), LabelWidth(75)] private string _key = "";
        [SerializeField] private string _description = "";
        [SerializeField] private GameObject _equipModel = null;
        [SerializeField] private GameObject _dropModel = null;
        [SerializeField] private ItemDefinition _projectile = null;
        [SerializeField] private ItemCategory _category = ItemCategory.None;
        [SerializeField] private ItemType _itemType = ItemType.None;
        [SerializeField] private ItemNameFormat _nameFormat = ItemNameFormat.None;
        [SerializeField] private EquipmentSlot _equipmentSlot = EquipmentSlot.None;
        [SerializeField] private List<RenderSlot> _renderSlots = new List<RenderSlot>();
        [SerializeField] private ItemMaterialAllowed _materialAllowed = ItemMaterialAllowed.None;
        [SerializeField] private Hands _hands = Hands.None;
        [SerializeField] private int _bestQualityAllowed = 0;
        [SerializeField] private bool _enchantable = false;
        [SerializeField] private int _modelIndex = -1;
        [SerializeField] private int _basePower = 0;
        [SerializeField] private int _encumbrance = 0;
        [SerializeField] private int _goldValue = 0;
        [SerializeField] private int _gemValue = 0;
        [SerializeField] private int _minimumMight = 0;
        [SerializeField] private int _minimumFinesse = 0;
        [SerializeField] private int _minimumMind = 0;
        
        [SerializeField] WeaponData _weaponData = null;
        [SerializeField] WearableData _wearableData = null;
        [SerializeField] AccessoryData _accessoryData = null;
        [SerializeField] UsableData _usableData = null;
        [SerializeField] IngredientData _ingredientData = null;
        
        public string Name { get => _name; }
        public string Key { get => _key; }
        public string Description { get => _description; }

        public Sprite Icon { get => _icon; }
        public GameObject EquipModel { get => _equipModel; }
        public GameObject DropModel { get => _dropModel; }
        public ItemType ItemType { get => _itemType; }
        public ItemCategory Category => _category;
        public ItemNameFormat NameFormat { get => _nameFormat; }
        public EquipmentSlot EquipmentSlot { get => _equipmentSlot; }
        public List<RenderSlot> RenderSlots { get => _renderSlots; }
        public ItemMaterialAllowed PrimaryMaterialAllowed { get => _materialAllowed; }
        public int BestQualityAllowed { get => _bestQualityAllowed; }
        public bool Enchantable { get => _enchantable; }
        public int ModelIndex { get => _modelIndex; }
        public int BasePower { get => _basePower; }
        public int Encumbrance { get => _encumbrance; }
        public int GoldValue { get => _goldValue; }
        public int GemValue { get => _gemValue; }
        public int MinimumMight => _minimumMight;
        public int MinimumFinesse => _minimumFinesse;
        public int MinimumMind => _minimumMind;
        public Hands Hands { get => _hands; }

        public WeaponData WeaponData { get => _weaponData; }
        public WearableData WearableData { get => _wearableData; }
        public AccessoryData AccessoryData { get => _accessoryData; }
        public UsableData UsableData { get => _usableData; }
        public IngredientData IngredientData => _ingredientData;

        public ItemDefinition Projectile => _projectile;

        public void SetName(string name)
        {
            _name = name;
        }

        public void SetKey(string key)
        {
            _key = key;
        }
        
        public string GetCodexText()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Item Type: " + _itemType + "\n");
            sb.Append("Equipment Slot: " + _equipmentSlot + "\n");
            sb.Append("Enchantable: " + _enchantable + "\n");
            sb.Append("Hands: " + _hands + "\n");
            sb.Append("Base Power: " + _basePower + "\n");
            sb.Append("Encumbrance: " + _encumbrance + "\n");
            sb.Append("Gold Value: " + _goldValue + "\n");
            sb.Append("Gem Value: " + _gemValue + "\n");
            //sb.Append("Render Slots: " + _renderSlot + "\n");

            if (_weaponData.HasData == true)
            {
                sb.Append("Damage Type: " + _weaponData.DamageType + "\n");
                sb.Append("Damage: " + _weaponData.MinDamage + "-" + _weaponData.MaxDamage + "\n");
                sb.Append("Range: " + _weaponData.Range + "\n");
                sb.Append("Delay: " + _weaponData.Delay + "\n");
                sb.Append("Weapon Type: " + _weaponData.WeaponType + "\n");
            }

            if (_wearableData.HasData == true)
            {
                sb.Append("Armor: " + _wearableData.Armor + "\n");
                sb.Append("Block: " + _wearableData.Block + "\n");
                sb.Append("Perception Modifier: " + _wearableData.PerceptionModifier + "\n");
                sb.Append("Spell Defense: " + _wearableData.SpellDefense + "\n");
                sb.Append("Wearable Type: " + _wearableData.WearableType + "\n");
            }

            if (_accessoryData.HasData == true)
            {
                sb.Append("Accessory Type: " + _accessoryData.AccessoryType + "\n");
            }

            if (_ingredientData.HasData == true)
            {
                sb.Append("Ingredient Type: " + _ingredientData.Type + "\n");
            }

            return sb.ToString();
        }

        public string GetHitSound()
        {
            if (_weaponData != null && _weaponData.HasData)
            {
                return _weaponData.HitSounds[Random.Range(0, _weaponData.HitSounds.Count)];
            }
            else
            {
                return "";
            }
        }

        public string GetMissSound()
        {
            if (_weaponData != null && _weaponData.HasData)
            {
                return _weaponData.MissSounds[Random.Range(0, _weaponData.MissSounds.Count)];
            }
            else
            {
                return "";
            }
        }
    }
}