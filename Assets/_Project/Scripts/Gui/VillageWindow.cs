using System.Collections;
using System.Collections.Generic;
using Descending.Party;
using Descending.World;
using ScriptableObjectArchitecture;
using TMPro;
using UnityEngine;

namespace Descending.Gui
{
    public class VillageWindow : GameWindow
    {
        [SerializeField] private TMP_Text _nameLabel = null;

        [SerializeField] private IntEvent onSpendCoins = null;
        [SerializeField] private IntEvent onSkipTime = null;
        
        private PartyController _party = null;
        
        public override void Setup()
        {
            Close();
        }

        public void SetParty(PartyController party)
        {
            _party = party;
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

        public void OnLoadVillage(Village village)
        {
            if (village == null) return;
            
            _nameLabel.text = village.Definition.Name;
            Open();
        }

        public void RentRoom1_ButtonClick()
        {
            for (int i = 0; i < _party.PartyData.Heroes.Count; i++)
            {
                _party.PartyData.Heroes[i].Restore("Life", Random.Range(1, 6));
            }
            
            onSpendCoins.Invoke(5);
            onSkipTime.Invoke(10);
        }

        public void RentRoom2_ButtonClick()
        {
            for (int i = 0; i < _party.PartyData.Heroes.Count; i++)
            {
                _party.PartyData.Heroes[i].Restore("Life", Random.Range(5, 11));
            }
            
            onSpendCoins.Invoke(10);
            onSkipTime.Invoke(8);
        }

        public void RentRoom3_ButtonClick()
        {
            for (int i = 0; i < _party.PartyData.Heroes.Count; i++)
            {
                _party.PartyData.Heroes[i].Restore("Life", Random.Range(10, 21));
            }
            
            onSpendCoins.Invoke(25);
            onSkipTime.Invoke(7);
        }

        public void RentRoom4_ButtonClick()
        {
            for (int i = 0; i < _party.PartyData.Heroes.Count; i++)
            {
                _party.PartyData.Heroes[i].Restore("Life", Random.Range(20, 51));
            }
            
            onSpendCoins.Invoke(100);
            onSkipTime.Invoke(6);
        }
    }
}
