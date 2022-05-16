using System;
using System.Collections;
using System.Collections.Generic;
using Descending.Combat;
using Descending.Core;
using Descending.Gui.Combat;
using ScriptableObjectArchitecture;
using TMPro;
using UnityEngine;

namespace Descending.Scene_Overworld.Gui
{
    public class InitiativePanel : MonoBehaviour
    {
        [SerializeField] private GameObject _heroWidgetPrefab = null;
        [SerializeField] private GameObject _enemyWidgetPrefab = null;
        [SerializeField] private Transform _initiativeWidgetsParent = null;

        private CombatParameters _combatParameters = null;
        private List<InitiativeWidget> _widgets = null;

        public void Setup(CombatParameters parameters)
        {
            _combatParameters = parameters;
            LoadList();
        }

        private void LoadList()
        {
            _initiativeWidgetsParent.ClearTransform();
            _widgets = new List<InitiativeWidget>();
            
            for (int i = 0; i < _combatParameters.InitiativeList.Count; i++)
            {
                if (_combatParameters.InitiativeList[i].Hero != null)
                {
                    GameObject clone = Instantiate(_heroWidgetPrefab, _initiativeWidgetsParent);
                    HeroInitiativeWidget widget = clone.GetComponent<HeroInitiativeWidget>();
                    widget.SetHero(i, _combatParameters.InitiativeList[i].Hero, _combatParameters.InitiativeList[i].InitiativeRoll);
                    _widgets.Add(widget);
                }
                else if (_combatParameters.InitiativeList[i].Enemy != null)
                {
                    GameObject clone = Instantiate(_enemyWidgetPrefab, _initiativeWidgetsParent);
                    EnemyInitiativeWidget widget = clone.GetComponent<EnemyInitiativeWidget>();
                    widget.SetEnemy(i, _combatParameters.InitiativeList[i].Enemy, _combatParameters.InitiativeList[i].InitiativeRoll);
                    _widgets.Add(widget);
                }
            }
        }
    }
}