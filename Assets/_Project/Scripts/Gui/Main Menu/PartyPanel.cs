using System.Collections;
using System.Collections.Generic;
using Descending.Core;
using ScriptableObjectArchitecture;
using UnityEngine;

namespace  Descending.Scene_MainMenu.Gui
{
    public class PartyPanel : MonoBehaviour
    {
        [SerializeField] private GameObject _container = null;
        [SerializeField] private GameObject _heroWidgetPrefab = null;
        [SerializeField] private Transform _heroWidgetsParent = null;

        [SerializeField] private BoolEvent onStartGame = null;
        [SerializeField] private BoolEvent onGenerateParty = null;
        [SerializeField] private BoolEvent onGenerateFavoriteParty = null;
        
        private List<HeroWidget> _heroWidgets = null;

        public void Setup()
        {
            _heroWidgets = new List<HeroWidget>();
            Hide();
        }

        public void SyncParty(PartyManager partyManager)
        {
            _heroWidgetsParent.ClearTransform();
            _heroWidgets.Clear();
            
            for (int i = 0; i < partyManager.PartyData.Heroes.Count; i++)
            {
                GameObject clone = Instantiate(_heroWidgetPrefab, _heroWidgetsParent);
                HeroWidget widget = clone.GetComponent<HeroWidget>();
                widget.SetHero(partyManager.PartyData.Heroes[i]);
                _heroWidgets.Add(widget);
            }
        }

        public void Show()
        {
            _container.SetActive(true);
        }

        public void Hide()
        {
            _container.SetActive(false);
        }

        public void RandomizeParty_ButtonClick()
        {
            onGenerateParty.Invoke(true);
        }

        public void GenerateFavoriteParty_ButtonClick()
        {
            onGenerateFavoriteParty.Invoke(true);
        }

        public void StartGame_ButtonClick()
        {
            onStartGame.Invoke(true);
        }
    }
}
