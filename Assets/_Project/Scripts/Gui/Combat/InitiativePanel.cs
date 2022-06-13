using System;
using System.Collections;
using System.Collections.Generic;
using Den.Tools;
using Descending.Combat;
using Descending.Core;
using Descending.Encounters;
using Descending.Gui.Combat;
using Descending.Party;
using UnityEngine;

namespace Descending.Gui
{
    public class InitiativePanel : MonoBehaviour
    {
        [SerializeField] private GameObject _heroWidgetPrefab = null;
        [SerializeField] private GameObject _enemyWidgetPrefab = null;
        [SerializeField] private Transform _initiativeWidgetsParent = null;

        private List<InitiativeWidget> _widgets = null;

        public void Setup()
        {
            _widgets = new List<InitiativeWidget>();
        }
        
        public void StartCombat(PartyManager partyManager, Encounter encounter)
        {
            Debug.Log("Starting Combat");
        }

        public void SyncInitiativeList(InitiativeDataList dataList)
        {
            Debug.Log("Syncing Initiative");
            _widgets.Clear();
            _initiativeWidgetsParent.ClearTransform();
            dataList.List.Sort((a, b) => a.InitiativeRoll.CompareTo(b.InitiativeRoll));
            
            for (int i = 0; i < dataList.List.Count; i++)
            {
                if (dataList.List[i].Hero != null)
                {
                    GameObject clone = Instantiate(_heroWidgetPrefab, _initiativeWidgetsParent);
                    HeroInitiativeWidget widget = clone.GetComponent<HeroInitiativeWidget>();
                    widget.SetHero(i, dataList.List[i].Hero, dataList.List[i].InitiativeRoll);
                    _widgets.Add(widget);
                }
                else if (dataList.List[i].Enemy != null)
                {
                    GameObject clone = Instantiate(_enemyWidgetPrefab, _initiativeWidgetsParent);
                    EnemyInitiativeWidget widget = clone.GetComponent<EnemyInitiativeWidget>();
                    widget.SetEnemy(i, dataList.List[i].Enemy, dataList.List[i].InitiativeRoll);
                    _widgets.Add(widget);
                }
            }
        }

        public void ProcessInitiative(int initiative)
        {
            for (int i = 0; i < _widgets.Count; i++)
            {
                _widgets[i].Deselect();
            }
            
            _widgets[initiative].Select();
        }
    }
}