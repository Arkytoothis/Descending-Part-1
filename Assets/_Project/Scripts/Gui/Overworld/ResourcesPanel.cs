using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Descending.Gui
{
    public class ResourcesPanel : MonoBehaviour
    {
        [SerializeField] private TMP_Text _coinsLabel = null;
        [SerializeField] private TMP_Text _gemsLabel = null;
        [SerializeField] private TMP_Text _materialsLabel = null;
        [SerializeField] private TMP_Text _suppliesLabel = null;
        [SerializeField] private GameObject _container = null;
        
        public void Setup()
        {
            
        }

        public void Show()
        {
            _container.SetActive(true);
        }

        public void Hide()
        {
            _container.SetActive(false);
        }
        
        public void OnSyncCoins(int coins)
        {
            _coinsLabel.text = "Coins " + coins;
        }
        
        public void OnSyncGems(int gems)
        {
            _gemsLabel.text = "Gems " + gems;
        }
        
        public void OnSyncMaterials(int materials)
        {
            _materialsLabel.text = "Materials " + materials;
        }
        
        public void OnSyncSupplies(int supplies)
        {
            _suppliesLabel.text = "Supplies " + supplies;
        }
    }
}
