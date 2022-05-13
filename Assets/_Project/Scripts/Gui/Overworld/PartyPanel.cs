using System;
using System.Collections;
using System.Collections.Generic;
using Descending.Core;
using Descending.Gui;
using Descending.Party;
using UnityEngine;

namespace Descending.Scene_Overworld.Gui
{
    public class PartyPanel : MonoBehaviour
    {
        [SerializeField] private GameObject _heroWidgetPrefab = null;
        [SerializeField] private Transform _heroWidgetsParent = null;
        [SerializeField] private GameObject _container = null;
        
        private PartyController _party = null;
        private List<HeroWidget> _heroWidgets = null;
        
        public void Setup()
        {
            _heroWidgets = new List<HeroWidget>();
        }

        public void Show()
        {
            _container.SetActive(true);
        }

        public void Hide()
        {
            _container.SetActive(false);
        }

        public void OnSetPartyController(PartyController party)
        {
            //Debug.Log("Party Synced - PartyPanel");
            _party = party;

            if (_party == null) return;

            _heroWidgets.Clear();
            _heroWidgetsParent.ClearTransform();
            
            for (int i = 0; i < _party.PartyData.Heroes.Count; i++)
            {
                GameObject clone = Instantiate(_heroWidgetPrefab, _heroWidgetsParent);
                HeroWidget widget = clone.GetComponent<HeroWidget>();
                widget.SetHero(_party.PartyData.Heroes[i], i);
                
                _heroWidgets.Add(widget);
            }
        }

        private void SyncParty()
        {
            for (int i = 0; i < _party.PartyData.Heroes.Count; i++)
            {
                _heroWidgets[i].SetHero(_party.PartyData.Heroes[i], i);
            }
        }

        public void OnSyncHero(int index)
        {
            _heroWidgets[index].SyncData();
        }
    }
}
