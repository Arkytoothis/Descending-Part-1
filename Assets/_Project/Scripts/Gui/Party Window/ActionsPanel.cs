using System.Collections;
using System.Collections.Generic;
using Descending.Characters;
using Descending.Core;
using UnityEngine;

namespace Descending.Gui.Party_Window
{
    public class ActionsPanel : MonoBehaviour
    {
        [SerializeField] private GameObject _actionWidgetPrefab = null;
        [SerializeField] private Transform _actionsParent = null;

        [SerializeField] private List<ActionConfigWidget> _actionWidgets = null;
        
        public void Setup()
        {
            
        }

        public void SelectHero(Hero hero)
        {
            _actionsParent.ClearTransform();
            _actionWidgets.Clear();
            
            for (int i = 0; i < hero.Abilities.ActionConfigs.Count; i++)
            {
                if (i < 12)
                {
                    GameObject clone = Instantiate(_actionWidgetPrefab, _actionsParent);
                    ActionConfigWidget widget = clone.GetComponent<ActionConfigWidget>();
                    widget.SetAbility(hero.Abilities.ActionConfigs[i].Ability);
                    _actionWidgets.Add(widget);
                }
            }
        }
    }
}