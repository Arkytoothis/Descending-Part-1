using System.Collections;
using System.Collections.Generic;
using Descending.Core;
using UnityEngine;

namespace  Descending.Scene_MainMenu.Gui
{
    public class PartyPanel : MonoBehaviour
    {
        [SerializeField] private GameObject _heroWidgetPrefab = null;
        [SerializeField] private Transform _heroWidgetsParent = null;

        private List<HeroWidget> _heroWidgets = null;

        public void Setup()
        {
            _heroWidgets = new List<HeroWidget>();
        }

        public void SyncParty(PartyManager partyManager)
        {
            _heroWidgetsParent.ClearTransform();
            _heroWidgets.Clear();
            
            for (int i = 0; i < partyManager.Heroes.Count; i++)
            {
                GameObject clone = Instantiate(_heroWidgetPrefab, _heroWidgetsParent);
                HeroWidget widget = clone.GetComponent<HeroWidget>();
                widget.SetHero(partyManager.Heroes[i]);
                _heroWidgets.Add(widget);
            }
        }
    }
}
