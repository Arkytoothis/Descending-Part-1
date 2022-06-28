using System;
using System.Collections;
using System.Collections.Generic;
using Descending.Core;
using Descending.Equipment;
using ScriptableObjectArchitecture;
using UnityEngine;

namespace Descending.Party
{
    public class StockpileController : MonoBehaviour
    {
        [SerializeField] private int _stockpileSlots = 40;
        [SerializeField] private List<Item> _items = null;

        [SerializeField] private StockpileControllerEvent onSyncStockpile = null;

        public int StockpileSlots => _stockpileSlots;
        public List<Item> Items => _items;

        
        private void Awake()
        {
            _items = new List<Item>();
            for (int i = 0; i < _stockpileSlots; i++)
            {
                _items.Add(null);
            }
        }

        public void SyncStockpile()
        {
            onSyncStockpile.Invoke(this);    
        }
        
        public void PickupItem(Item item)
        {
            for (int i = 0; i < _items.Count; i++)
            {
                if (_items[i] == null || _items[i].Name == "")
                {
                    _items[i] = new Item(item);
                    break;
                }
                else
                {
                    if (_items[i].ItemDefinition.Key == item.ItemDefinition.Key && item.ItemDefinition.Stackable == true)
                    {
                        _items[i].AddToStack(1);
                        break;
                    }
                }
            }
            
            SyncStockpile();
        }

        public bool HasItem(ItemDefinition item, int amount)
        {
            bool hasItem = false;

            for (int i = 0; i < _items.Count; i++)
            {
                if (_items[i] != null && _items[i].ItemDefinition == item && _items[i].StackSize >= amount)
                {
                    hasItem = true;
                    break;
                }
            }

            return hasItem;
        }

        public void RemoveItem(ItemDefinition item, int amount)
        {
            for (int i = 0; i < _items.Count; i++)
            {
                if (_items[i] != null && _items[i].ItemDefinition == item && _items[i].StackSize >= amount)
                {
                    _items[i].StackSize -= amount;

                    if (_items[i].StackSize <= 0)
                    {
                        _items[i] = null;
                    }
                    
                    break;
                }
            }
            
            SyncStockpile();
        }

        public void ClearStockpileSlot(int index)
        {
            _items[index] = null;
            SyncStockpile();
        }
    }
}