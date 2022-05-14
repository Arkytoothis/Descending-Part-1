using System.Collections;
using System.Collections.Generic;
using Descending.Party;
using Descending.World;
using ScriptableObjectArchitecture;
using TMPro;
using UnityEngine;

namespace Descending.Gui
{
    public class SmithWindow : GameWindow
    {
        [SerializeField] private TMP_Text _nameLabel = null;

        [SerializeField] private IntEvent onSpendCoins = null;

        private Smith _smith = null;
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

            if (_smith != null)
            {
                _smith.EndInteraction();
            }
        }

        public void CloseButtonClick()
        {
            Close();
        }

        public void OnLoadSmith(Smith smith)
        {
            _smith = smith;
            if (_smith == null) return;
            
            _nameLabel.text = _smith.Definition.Name;
            Open();
        }
        
    }
}
