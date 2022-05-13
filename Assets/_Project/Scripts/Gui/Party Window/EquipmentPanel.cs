using System.Collections;
using System.Collections.Generic;
using Descending.Characters;
using UnityEngine;

namespace Descending.Gui.Party_Window
{
    public class EquipmentPanel : MonoBehaviour
    {
        //[SerializeField] private Transform _equippedItemsParent = null;
        //[SerializeField] private Transform _accessoriesParent = null;
        //[SerializeField] private Transform _stockpileParent = null;

        [SerializeField] private List<EquippedItemWidget> _equippedItemWidgets = null;
        [SerializeField] private List<EquippedItemWidget> _accessoryWidgets = null;
        [SerializeField] private List<StockpileWidget> _stockpileWidgets = null;
        
        public void Setup()
        {
            
        }

        public void SelectHero(Hero hero)
        {
            for (int i = 0; i < _equippedItemWidgets.Count; i++)
            {
                _equippedItemWidgets[i].Clear();
                
                if(hero.Inventory.EquippedItems[i] != null)
                {
                    _equippedItemWidgets[i].SetItem(hero.Inventory.EquippedItems[i]);
                }
            }
            
            for (int i = 0; i < _accessoryWidgets.Count; i++)
            {
                _accessoryWidgets[i].Clear();
            }
            
            for (int i = 0; i < _stockpileWidgets.Count; i++)
            {
                _stockpileWidgets[i].Clear();
            }
        }
    }
}