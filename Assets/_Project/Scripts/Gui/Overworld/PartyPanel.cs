using System;
using System.Collections;
using System.Collections.Generic;
using Descending.Core;
using Descending.Gui;
using Descending.Party;
using UnityEngine;

namespace Descending.Gui
{
    public class PartyPanel : MonoBehaviour
    {
        [SerializeField] private GameObject _heroWidgetPrefab = null;
        [SerializeField] private Transform _heroWidgetsParent = null;
        [SerializeField] private GameObject _container = null;
        
        private PartyData _partyData = null;
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

        public void OnSyncPartyData(PartyData partyData)
        {
            //Debug.Log("Party Synced - PartyPanel");
            _partyData = partyData;

            if (_partyData == null) return;

            _heroWidgets.Clear();
            _heroWidgetsParent.ClearTransform();
            
            for (int i = 0; i < _partyData.Heroes.Count; i++)
            {
                GameObject clone = Instantiate(_heroWidgetPrefab, _heroWidgetsParent);
                HeroWidget widget = clone.GetComponent<HeroWidget>();
                widget.SetHero(this, _partyData.Heroes[i], i);
                
                _heroWidgets.Add(widget);
            }
            
            SelectHero(0);
        }

        public void OnSyncHero(int index)
        {
            _heroWidgets[index].SyncData();
        }

        public void SelectHero(int index)
        {
            for (int i = 0; i < _heroWidgets.Count; i++)
            {
                _heroWidgets[i].Deselect();
            }
            
            _heroWidgets[index].Select();
        }

        public void OnSetLeader(int index)
        {
            SelectHero(index);
        }
    }
}
