using Descending.Characters;
using Descending.Core;
using Descending.Equipment.Enchantments;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Descending.Equipment
{
    [System.Serializable]
    public class Item
    {
        [SerializeField] private string _name = "";
        [SerializeField] private string _definitionKey = "";
        [SerializeField] private string _description = "";
        [SerializeField] private int _modelIndex = -1;

        [SerializeField] private ItemType _itemType = ItemType.None;
        [SerializeField] private ItemNameFormat _nameFormat = ItemNameFormat.None;
        [SerializeField] private EquipmentSlot _equipmentSlot = EquipmentSlot.None;
        [SerializeField] private List<RenderSlot> _renderSlots = new List<RenderSlot>();
        [SerializeField] private ItemMaterialAllowed _materialAllowed;

        [SerializeField] private int _stackSize = 0;
        [SerializeField] private int _itemPower = 0;
        [SerializeField] private int _encumbrance = 0;
        [SerializeField] private int _goldValue = 0;
        [SerializeField] private int _gemValue = 0;
        [SerializeField] private int _usesLeft = 0;

        [SerializeField] private string _rarityKey = "";
        [SerializeField] private string _materialKey = "";
        [SerializeField] private string _qualityKey = "";
        [SerializeField] private string _prefixEnchantKey = "";
        [SerializeField] private string _suffixEnchantKey = "";

        public string Name => _name;
        public string Key => _definitionKey;
        public string Description => _description;
        public ItemType ItemType => _itemType;
        public ItemNameFormat NameFormat => _nameFormat;
        public EquipmentSlot EquipmentSlot => _equipmentSlot;
        public List<RenderSlot> RenderSlots => _renderSlots;
        public ItemMaterialAllowed MaterialAllowed => _materialAllowed;
        public int ModelIndex => _modelIndex;

        public int StackSize
        {
            get => _stackSize;
            set => _stackSize = value;
        }

        public int ItemPower => _itemPower;
        public int Encumbrance => _encumbrance;
        public int GoldValue => _goldValue;
        public int GemValue => _gemValue;
        public int UsesLeft => _usesLeft;
        public int MaxUses => ItemDefinition.UsableData.MaxUses;

        public string RarityKey => _rarityKey;

        public Sprite Icon
        {
            get {
                if (_definitionKey != "")
                {
                    return Database.instance.Items.GetItem(_definitionKey).Icon;
                }
                else
                {
                    return Database.instance.BlankSprite;
                }
            }
        }

        public string MaterialKey => _materialKey;
        public string QualityKey => _qualityKey;
        public string PrefixEnchantKey => _prefixEnchantKey;
        public string SuffixEnchantKey => _suffixEnchantKey;

        public ItemDefinition ItemDefinition => Database.instance.Items.GetItem(_definitionKey);
        public MaterialDefinition MaterialDefinition => Database.instance.Materials.GetMaterial(_materialKey);
        public EnchantmentDefinition PrefixDefinition => Database.instance.Enchants.GetEnchant(_prefixEnchantKey);
        public EnchantmentDefinition SuffixDefinition => Database.instance.Enchants.GetEnchant(_suffixEnchantKey);

        public Item()
        {
            _definitionKey = "";
            _name = "";
            _itemType = ItemType.None;
            _nameFormat = ItemNameFormat.None;
            _equipmentSlot = EquipmentSlot.None;
            _renderSlots = new List<RenderSlot>();
            _materialAllowed = ItemMaterialAllowed.None;
            _modelIndex = -1;
            _stackSize = 0;
            _itemPower = 0;
            _encumbrance = 0;
            _rarityKey = "";
            _materialKey = "";
            _qualityKey = "";
            _prefixEnchantKey = "";
            _suffixEnchantKey = "";
        }

        public Item(ItemDefinition definition)
        {
            _definitionKey = definition.Key;
            _name = definition.Name;
            _itemType = definition.ItemType;
            _nameFormat = definition.NameFormat;
            _equipmentSlot = definition.EquipmentSlot;
            _renderSlots = definition.RenderSlots;
            _materialAllowed = definition.PrimaryMaterialAllowed;
            _modelIndex = definition.ModelIndex;
            _itemPower = definition.BasePower;
            _encumbrance = definition.Encumbrance;
            _usesLeft = definition.UsableData.MaxUses;
            _stackSize = 1;
            _rarityKey = "";
            _materialKey = "";
            _qualityKey = "";
            _prefixEnchantKey = "";
            _suffixEnchantKey = "";
        }

        public Item(Item item)
        {
            if (item == null) return;

            _definitionKey = item.Key;
            _name = item.Name;
            _itemType = item.ItemType;
            _nameFormat = item.NameFormat;
            _equipmentSlot = item.EquipmentSlot;
            _renderSlots = item.RenderSlots;
            _materialAllowed = item.MaterialAllowed;
            _modelIndex = item.ModelIndex;

            _stackSize = item._stackSize;
            _itemPower = item._itemPower;
            _encumbrance = item._encumbrance;
            _goldValue = item._goldValue;
            _gemValue = item._gemValue;
            
            _rarityKey = item._rarityKey;
            _materialKey = item.MaterialKey;
            _qualityKey = item.QualityKey;
            _prefixEnchantKey = item.PrefixEnchantKey;
            _suffixEnchantKey = item.SuffixEnchantKey;
            _usesLeft = item.UsesLeft;
        }

        public void AddToStack(int amountToAdd)
        {
            _stackSize += amountToAdd;
        }
        
        public void SetMaterial(MaterialDefinition material)
        {
            if (material == null)
            {
                _materialKey = "";
            }
            else
            {
                _materialKey = material.Key;
                CalculatePower();
                CalculateEncumbrance();
                CalculateRarity();
            }
        }

        public string DisplayName()
        {
            string quality = "";
            string prefix = "";
            string suffix = "";

            // if (_quality != null)
            // {
            //     quality = _quality.Name;
            // }
            //
            // if (_prefixEnchant != null)
            // {
            //     prefix = " " + _prefixEnchant.Name;
            // }
            //
            // if (_suffixEnchant != null)
            // {
            //     suffix = " " + _suffixEnchant.Name;
            // }

            string name = "";

            if (NameFormat == ItemNameFormat.Material_First)
            {
                name = quality + prefix + " " + _materialKey + " " + _name + suffix;
            }
            else if (_nameFormat == ItemNameFormat.Material_Middle)
            {
                name = quality + prefix + " " + _materialKey + " " + _name + suffix;
            }
            else if (_nameFormat == ItemNameFormat.Material_Last)
            {
                name = quality + prefix + _name + " " + _materialKey + suffix;
            }

            return name;
        }

        public void CalculateRarity()
        {
            foreach (RarityDefinition rarity in Database.instance.Rarities.Rarities)
            {
                if (_itemPower >= rarity.MinimumPower && _itemPower <= rarity.MaximumPower)
                {
                    _rarityKey = rarity.Key;
                    break;
                }
            }
            
            if(_rarityKey == "")
                _rarityKey = "Common";
        }

        public Color GetRarityColor()
        {
            if (_rarityKey != "")
            {
                return Database.instance.Rarities.GetRarity(_rarityKey).Color;
            }
            else
            {
                return Color.gray;
            }
        }
        
        public string GetTooltipText()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Power: ");
            sb.Append(_itemPower + " " + _rarityKey);
            sb.Append("\n");

            sb.Append("Encumbrance: ");
            sb.Append(_encumbrance);
            sb.Append("\n");

            if (ItemDefinition.MinimumMight > 0)
            {
                sb.Append("Might: ");
                sb.Append(ItemDefinition.MinimumMight);
                sb.Append("\n");
            }

            if (ItemDefinition.MinimumFinesse > 0)
            {
                sb.Append("Finesse: ");
                sb.Append(ItemDefinition.MinimumFinesse);
                sb.Append("\n");
            }

            if (ItemDefinition.MinimumMind > 0)
            {
                sb.Append("Mind: ");
                sb.Append(ItemDefinition.MinimumMind);
                sb.Append("\n");
            }

            if (ItemDefinition.Hands != Hands.None)
            {
                sb.Append("Hands: ");
                sb.Append(ItemDefinition.Hands);
                sb.Append("\n");
            }

            if (ItemDefinition.WeaponData.HasData == true)
            {
                sb.Append("\n" + ItemDefinition.WeaponData.GetTooltipText());
            }

            if (ItemDefinition.WearableData.HasData == true)
            {
                sb.Append("\n" + ItemDefinition.WearableData.GetTooltipText());
            }

            if (ItemDefinition.AccessoryData.HasData == true)
            {
                sb.Append("\n" + ItemDefinition.AccessoryData.GetTooltipText());
            }

            if (ItemDefinition.UsableData.HasData == true)
            {
                sb.Append("\n" + ItemDefinition.UsableData.GetTooltipText());
            }

            //sb.Append("\nMaterial:  " + MaterialDefinition.GetTooltipText() + "\n");

            // if (_quality != null)
            // {
            //     sb.Append("Quality:  " + _quality.GetTooltipText() + "\n");
            // }
            //
            // if (_prefixEnchant != null)
            // {
            //     sb.Append("Prefix:  " + _prefixEnchant.GetTooltipText() + "\n");
            // }
            //
            // if (_suffixEnchant != null)
            // {
            //     sb.Append("Suffix:  " + _suffixEnchant.GetTooltipText() + "\n");
            // }

            return sb.ToString();
        }

        public void CalculatePower()
        {
            _itemPower = ItemDefinition.BasePower;
            _itemPower += MaterialDefinition.ItemPower;

            if (_prefixEnchantKey != "")
            {
                _itemPower += PrefixDefinition.ItemPower;
            }

            if (_suffixEnchantKey != "")
            {
                _itemPower += SuffixDefinition.ItemPower;
            }
            
            // if (_quality != null)
            // {
            //     _itemPower += _quality.ItemPower;
            // }
            //
            // if (_prefixEnchant != null)
            // {
            //     _itemPower += _prefixEnchant.ItemPower;
            // }
            //
            // if (_suffixEnchant != null)
            // {
            //     _itemPower += _suffixEnchant.ItemPower;
            // }
        }

        public void CalculateEncumbrance()
        {
            _encumbrance = ItemDefinition.Encumbrance;
            int encumbranceBonus = (int) ((float) _encumbrance * MaterialDefinition.EncumbranceModifier);
            _encumbrance += encumbranceBonus;

            // if (_quality != null)
            // {
            //     int qualityBonus = (int) ((float) _encumbrance * _quality.EncumbranceModifier);
            //     _encumbrance += qualityBonus;
            // }
            //
            // if (_prefixEnchant != null)
            // {
            //     int prefixBonus = (int) ((float) _encumbrance * _prefixEnchant.EncumbranceModifier);
            //     _encumbrance += prefixBonus;
            // }
            //
            // if (_suffixEnchant != null)
            // {
            //     int suffixBonus = (int) ((float) _encumbrance * _suffixEnchant.EncumbranceModifier);
            //     _encumbrance += suffixBonus;
            // }
        }

        public void SetQualityEnchant(Enchantment enchant)
        {
            if (enchant != null)
            {
                _qualityKey = enchant.Definition.Key;
                CalculatePower();
                CalculateEncumbrance();
                CalculateRarity();
            }
            else
            {
                _qualityKey = "";
            }
        }

        public void SetPrefixEnchant(Enchantment enchant)
        {
            if (enchant != null)
            {
                _prefixEnchantKey = enchant.Definition.Key;
                CalculatePower();
                CalculateEncumbrance();
                CalculateRarity();
            }
        }

        public void SetSuffixEnchant(Enchantment enchant)
        {
            if (enchant != null)
            {
                _suffixEnchantKey = enchant.Definition.Key;
                CalculatePower();
                CalculateEncumbrance();
                CalculateRarity();
            }
        }

        public bool Use(GameEntity user)
        {
            bool success = false;
            //Debug.Log(pc.Details.Name.ShortName + " uses " + DisplayName());
            ItemDefinition definition = Database.instance.Items.GetItem(_definitionKey);

            if (definition.UsableData.HasData == true)
            {
                _usesLeft--;
                definition.UsableData.Use(user, new List<GameEntity> { user });
            }

            return success;
        }

        //public bool Use(Enemy enemy)
        //{
        //    bool success = false;

        //    Debug.Log(enemy.Details.Name + " uses " + DisplayName());

        //    return success;
        //}

        public int GetBonus()
        {
            int bonus = 0;


            return bonus;
        }

        public WeaponData GetWeaponData()
        {
            if (ItemDefinition.WeaponData != null && ItemDefinition.WeaponData.HasData == true)
            {
                return ItemDefinition.WeaponData;
            }
            else
            {
                return null;
            }
        }

        public void CalculateValue()
        {
            ItemDefinition definition = Database.instance.Items.GetItem(_definitionKey);
            _goldValue = definition.GoldValue;
            _gemValue = definition.GemValue;

            //if (_material != null)
            //{
            //    _goldValue += (int)((float)_goldValue * _material.GoldValue);
            //    _gemValue += _material.GemValue;
            //}

            // if (_quality != null)
            // {
            //     _goldValue += (int) ((float) _goldValue * _quality.GoldValue);
            //     _gemValue += _quality.GemValue;
            // }
            //
            // if (_prefixEnchant != null)
            // {
            //     _goldValue += (int) ((float) _goldValue * _prefixEnchant.GoldValue);
            //     _gemValue += _prefixEnchant.GemValue;
            // }
            //
            // if (_suffixEnchant != null)
            // {
            //     _goldValue += (int) ((float) _goldValue * _suffixEnchant.GoldValue);
            //     _gemValue += _suffixEnchant.GemValue;
            // }
        }

        public GameObject SpawnItemModel(Transform parent, int layer)
        {
            ItemDefinition def = ItemDefinition;

            if (def.EquipModel != null)
            {
                GameObject clone = GameObject.Instantiate(def.EquipModel, parent);
                clone.layer = layer;
                
                for (int i = 0; i < clone.transform.childCount; i++)
                {
                    clone.transform.GetChild(i).gameObject.layer = layer;
                }
                
                ResetScaleAndParent(clone.transform, parent);
                
                return clone;
            }
            else
                return null;
        }

        public void ResetScaleAndParent(Transform t, Transform parent)
        {
            t.SetParent(null);
            t.localScale = Vector3.one;
            t.SetParent(parent);
        }
    }
}