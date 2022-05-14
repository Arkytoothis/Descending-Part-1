using System.Collections;
using System.Collections.Generic;
using Descending.Party;
using Descending.World;
using ScriptableObjectArchitecture;
using TMPro;
using UnityEngine;

namespace Descending.Gui
{
    public class ChapelWindow : GameWindow
    {
        [SerializeField] private TMP_Text _nameLabel = null;

        [SerializeField] private IntEvent onSpendCoins = null;
        //[SerializeField] private IntEvent onSkipTime = null;

        private Chapel _chapel = null;
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

            if (_chapel != null)
            {
                _chapel.EndInteraction();
            }
        }

        public void CloseButtonClick()
        {
            Close();
        }

        public void OnLoadChapel(Chapel chapel)
        {
            _chapel = chapel;
            if (chapel == null) return;
            
            _nameLabel.text = _chapel.Definition.Name;
            Open();
        }

        public void Cure_ButtonClick()
        {
            for (int i = 0; i < _party.PartyData.Heroes.Count; i++)
            {
                _party.PartyData.Heroes[i].Restore("Life", Random.Range(1, 6));
            }
            
            onSpendCoins.Invoke(5);
            //onSkipTime.Invoke(10);
        }
    }
}
