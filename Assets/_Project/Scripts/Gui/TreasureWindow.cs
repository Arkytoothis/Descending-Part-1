using System.Collections;
using System.Collections.Generic;
using Descending.Core;
using Descending.World;
using ScriptableObjectArchitecture;
using TMPro;
using UnityEngine;

namespace Descending.Gui
{
    public class TreasureWindow : GameWindow
    {
        [SerializeField] private TMP_Text _treasureLabel = null;
        [SerializeField] private TMP_Text _coinsLabel = null;
        [SerializeField] private TMP_Text _gemsLabel = null;
        [SerializeField] private TMP_Text _suppliesLabel = null;
        [SerializeField] private TMP_Text _lockLabel = null;
        [SerializeField] private TMP_Text _hiddenLabel = null;

        [SerializeField] private GameObject _itemWidgetPrefab = null;
        [SerializeField] private Transform _itemWidgetsParent = null;

        private List<StockpileWidget> _widgets = null;
        private Treasure _treasure = null;
        
        public override void Setup()
        {
            _widgets = new List<StockpileWidget>();
            Close();
        }

        public override void Open()
        {
            Time.timeScale = 0;
            _isOpen = true;
            _container.SetActive(true);
        }

        public override void Close()
        {
            Time.timeScale = 1;
            _isOpen = false;
            _container.SetActive(false);
        }

        public void CloseButtonClick()
        {
            Close();
        }

        public void LootTreasureButtonClick()
        {
            LootTreasure();
        }

        private void LootTreasure()
        {
            _treasure.Loot();
            _treasure = null;
            Close();
        }

        public void OnLoadTreasure(Treasure treasure)
        {
            _treasure = treasure;

            if (_treasure == null) return;
            
            _treasureLabel.text = "Level " + _treasure.Level + " " + _treasure.name;
            _coinsLabel.text = "Coins " + _treasure.Coins;
            _gemsLabel.text = "Gems " + _treasure.Gems;
            _suppliesLabel.text = "Supplies " + _treasure.Supplies;
            _lockLabel.text = "Lock Level " + _treasure.LockLevel;
            _hiddenLabel.text = "Hidden Level " + _treasure.HiddenLevel;
            
            _itemWidgetsParent.ClearTransform();
            _widgets.Clear();

            for (int i = 0; i < _treasure.Items.Count; i++)
            {
                GameObject clone = Instantiate(_itemWidgetPrefab, _itemWidgetsParent);
                StockpileWidget widget = clone.GetComponent<StockpileWidget>();
                widget.Setup();
            }
            
            Open();
        }
    }
}
