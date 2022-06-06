using System.Collections;
using System.Collections.Generic;
using Descending.Attributes;
using Descending.Characters;
using Descending.Core;
using UnityEngine;

namespace Descending.Equipment
{
    public class InventoryController : MonoBehaviour
    {
        public const int MAX_ACCESSORY_SLOTS = 6;
        
        [SerializeField] private Item[] _equippedItems = null;
        [SerializeField] private Item[] _accessories = null;
        [SerializeField] private Item[] _stockpile = null;
        
        [SerializeField] private int _accessorySlots = 2;
        [SerializeField] private int _stockpileSlots = 40;
        [SerializeField] private BodyRenderer _worldBody = null;
        [SerializeField] private BodyRenderer _portraitBody = null;

        private Genders _gender = Genders.None;
        
        public Item[] EquippedItems => _equippedItems;
        public Item[] Accessories => _accessories;
        public int AccessorySlots => _accessorySlots;
        public Item[] Stockpile => _stockpile;
        public int StockpileSlots => _stockpileSlots;

        public void Setup(BodyRenderer worldBody, BodyRenderer portraitBody, Genders gender, RaceDefinition race, ProfessionDefinition profession, bool equipWeapons, bool portraitEquip)
        {
            _worldBody = worldBody;
            _portraitBody = portraitBody;
            
            _gender = gender;
            
            _equippedItems = new Item[(int) EquipmentSlot.Number];
            _accessories = new Item[MAX_ACCESSORY_SLOTS];
            _stockpile = new Item[_stockpileSlots];
            
            for (int i = 0; i < (int)EquipmentSlot.Number; i++)
            {
                _equippedItems[i] = null;
            }

            for (int i = 0; i < MAX_ACCESSORY_SLOTS; i++)
            {
                _accessories[i] = null;
            }

            for (int i = 0; i < _stockpileSlots; i++)
            {
                _stockpile[i] = null;
            }
            
            for (int i = 0; i < profession.StartingItems.Count; i++)
            {
                Item item = ItemGenerator.GenerateItem(profession.StartingItems[i]);

                if (item.ItemDefinition.Category == ItemCategory.Weapons && equipWeapons == false)
                {
                    continue;
                }
                else
                {
                    EquipItem(item, portraitEquip);
                }
            }
        }

        public void PickupItem(Item item)
        {
            for (int i = 0; i < _stockpile.Length; i++)
            {
                if (_stockpile[i] == null)
                {
                    _stockpile[i] = new Item(item);
                    break;
                }
                else
                {
                    if (_stockpile[i].ItemDefinition.Key == item.ItemDefinition.Key)
                    {
                        _stockpile[i].AddToStack(1);
                        break;
                    }
                }
            }
        }

        // public bool HasIngredients(RecipeDefinition recipe)
        // {
        //     bool hasIngredients = true;
        //     
        //     foreach (RecipeIngredient recipeIngredient in recipe.Ingredients)
        //     {
        //         if (HasItem(recipeIngredient.Ingredient, recipeIngredient.IngredientAmount) == false)
        //         {
        //             hasIngredients = false;
        //         }
        //     }
        //     
        //     return hasIngredients;
        // }

        public bool HasItem(ItemDefinition item, int amount)
        {
            bool hasItem = false;

            for (int i = 0; i < _stockpile.Length; i++)
            {
                if (_stockpile[i] != null && _stockpile[i].ItemDefinition == item && _stockpile[i].StackSize >= amount)
                {
                    hasItem = true;
                    break;
                }
            }

            return hasItem;
        }

        public void RemoveItem(ItemDefinition item, int amount)
        {
            for (int i = 0; i < _stockpile.Length; i++)
            {
                if (_stockpile[i] != null && _stockpile[i].ItemDefinition == item && _stockpile[i].StackSize >= amount)
                {
                    _stockpile[i].StackSize -= amount;

                    if (_stockpile[i].StackSize <= 0)
                    {
                        _stockpile[i] = null;
                    }
                    
                    break;
                }
            }
        }

        public void ClearStockpileSlot(int index)
        {
            _stockpile[index] = null;
        }
        
        public void LoadData(BodyRenderer worldBody, BodyRenderer portraitBody, Genders gender, InventorySaveData saveData, bool portraitEquip)
        {
            _worldBody = worldBody;
            _portraitBody = portraitBody;
            _gender = gender;
            _equippedItems = new Item[saveData.EquippedItems.Length];
            _accessories = new Item[saveData.Accessories.Length];
            
            for (int i = 0; i < saveData.EquippedItems.Length; i++)
            {
                _equippedItems[i] = new Item(saveData.EquippedItems[i]);
            }
        
            for (int i = 0; i < saveData.Accessories.Length; i++)
            {
                _accessories[i] = new Item(saveData.Accessories[i]);
            }
            
            for (int i = 0; i < saveData.EquippedItems.Length; i++)
            {
                if (saveData.EquippedItems[i].Key == "" || saveData.EquippedItems[i].ItemDefinition.Key == "") continue;
                
                EquipItem(saveData.EquippedItems[i], portraitEquip);
            }
        }

        public void EquipItem(Item item,bool portraitEquip)
        {
            //Debug.Log("Name: " + item.Name + " Slot: " + item.EquipmentSlot);
            if (_equippedItems[(int) item.EquipmentSlot] == null)
            {
                //Debug.Log("Equipping");
                _equippedItems[(int) item.EquipmentSlot] = new Item(item);
                _worldBody.EquipItem(item);

                if (portraitEquip == true)
                {
                    _portraitBody.EquipItem(item);
                }
            }
            else
            {
                //Debug.Log("Swapping");
                PickupItem(_equippedItems[(int) item.EquipmentSlot]);
                _equippedItems[(int) item.EquipmentSlot] = new Item(item);
                _worldBody.EquipItem(item);

                if (portraitEquip == true)
                {
                    _portraitBody.EquipItem(item);
                }
            }
        }

        public void UnequipItem(Item item)
        {
            
        }

        public Item GetEquippedItem(EquipmentSlot slot)
        {
            return _equippedItems[(int) slot];
        }

        public Item GetEquippedWeapon()
        {
            return _equippedItems[(int) EquipmentSlot.Right_Hand];
        }

        public WeaponData GetEquippedWeaponData()
        {
            return _equippedItems[(int) EquipmentSlot.Right_Hand].GetWeaponData();
        }

        public string GetRandomWalkSound()
        {
            return _equippedItems[(int) EquipmentSlot.Armor].GetWearableData().GetRandomWalkSound();
        }
    }

    [System.Serializable]
    public class InventorySaveData
    {
        [SerializeField] private Item[] _equippedItems = null;
        [SerializeField] private Item[] _accessories = null;
        [SerializeField] private int _accessorySlots = 0;

        public Item[] EquippedItems => _equippedItems;
        public Item[] Accessories => _accessories;
        public int AccessorySlots => _accessorySlots;

        public InventorySaveData(Hero hero)
        {
            _accessorySlots = hero.Inventory.AccessorySlots;
            _equippedItems = new Item[hero.Inventory.EquippedItems.Length];
            _accessories = new Item[hero.Inventory.Accessories.Length];
            
            for (int i = 0; i < hero.Inventory.EquippedItems.Length; i++)
            {
                _equippedItems[i] = new Item(hero.Inventory.EquippedItems[i]);
            }

            for (int i = 0; i < hero.Inventory.Accessories.Length; i++)
            {
                _accessories[i] = new Item(hero.Inventory.Accessories[i]);
            }
        }
    }
}