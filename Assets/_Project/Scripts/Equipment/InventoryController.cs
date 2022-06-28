using System.Collections;
using System.Collections.Generic;
using System.Data;
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
        
        [SerializeField] private int _accessorySlots = 2;
        [SerializeField] private BodyRenderer _portraitBody = null;

        private Genders _gender = Genders.None;
        
        public Item[] EquippedItems => _equippedItems;
        public Item[] Accessories => _accessories;
        public int AccessorySlots => _accessorySlots;

        public void Setup(BodyRenderer portraitBody, Genders gender, RaceDefinition race, ProfessionDefinition profession)
        {
            _portraitBody = portraitBody;
            
            _gender = gender;
            
            _equippedItems = new Item[(int) EquipmentSlot.Number];
            _accessories = new Item[MAX_ACCESSORY_SLOTS];
            
            for (int i = 0; i < (int)EquipmentSlot.Number; i++)
            {
                _equippedItems[i] = null;
            }

            for (int i = 0; i < MAX_ACCESSORY_SLOTS; i++)
            {
                _accessories[i] = null;
            }
            
            for (int i = 0; i < profession.StartingItems.Count; i++)
            {
                Item item = ItemGenerator.GenerateItem(profession.StartingItems[i]);
                EquipItem(item);
            }
        }

        
        
        public void LoadData(BodyRenderer portraitBody, Genders gender, InventorySaveData saveData)
        {
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
                
                EquipItem(saveData.EquippedItems[i]);
            }
        }

        public void EquipItem(Item item)
        {
            //Debug.Log("Name: " + item.Name + " Slot: " + item.EquipmentSlot);
            if (_equippedItems[(int) item.EquipmentSlot] == null)
            {
                //Debug.Log("Equipping");
                _equippedItems[(int) item.EquipmentSlot] = new Item(item);
                _portraitBody.EquipItem(item);
            }
            else
            {
                //Debug.Log("Swapping");
                //PickupItem(_equippedItems[(int) item.EquipmentSlot]);
                _equippedItems[(int) item.EquipmentSlot] = new Item(item);
                _portraitBody.EquipItem(item);
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