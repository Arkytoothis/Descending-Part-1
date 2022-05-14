using System.Collections;
using System.Collections.Generic;
using Descending.Party;
using Descending.World;
using ScriptableObjectArchitecture;
using TMPro;
using UnityEngine;

namespace Descending.Gui
{
    public class EnchanterWindow : GameWindow
    {
        [SerializeField] private TMP_Text _nameLabel = null;

        [SerializeField] private IntEvent onSpendCoins = null;

        private Enchanter _enchanter = null;
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

            if (_enchanter != null)
            {
                _enchanter.EndInteraction();
            }
        }

        public void CloseButtonClick()
        {
            Close();
        }

        public void OnLoadEnchanter(Enchanter enchanter)
        {
            _enchanter = enchanter;
            if (_enchanter == null) return;
            
            _nameLabel.text = _enchanter.Definition.Name;
            Open();
        }
        
    }
}
