using System.Collections;
using System.Collections.Generic;
using Descending.Core;
using Descending.World;
using ScriptableObjectArchitecture;
using TMPro;
using UnityEngine;

namespace Descending.Gui
{
    public class TreasurePileWindow : GameWindow
    {
        [SerializeField] private TMP_Text _treasureLabel = null;
        [SerializeField] private TMP_Text _coinsLabel = null;
        [SerializeField] private TMP_Text _gemsLabel = null;
        [SerializeField] private TMP_Text _materialsLabel = null;
        [SerializeField] private TMP_Text _suppliesLabel = null;
        
        private TreasurePile _treasurePile = null;
        
        public override void Setup()
        {
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

            if (_treasurePile != null)
            {
                _treasurePile.EndInteraction();
            }
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
            _treasurePile.Loot();
            _treasurePile = null;
            Close();
        }

        public void OnLoadTreasurePile(TreasurePile treasurePile)
        {
            _treasurePile = treasurePile;

            if (_treasurePile == null) return;
            
            _treasureLabel.text = "Level " + _treasurePile.Level + " " + _treasurePile.name;

            _coinsLabel.text = "Coins " + _treasurePile.Coins;
            _gemsLabel.text = "Gems  " + _treasurePile.Gems;
            _materialsLabel.text = "Materials " + _treasurePile.Materials;
            _suppliesLabel.text = "Supplies " + _treasurePile.Supplies;
            
            Open();
        }
    }
}
