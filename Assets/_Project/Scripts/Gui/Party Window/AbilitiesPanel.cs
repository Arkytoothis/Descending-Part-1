using System.Collections;
using System.Collections.Generic;
using Descending.Characters;
using Descending.Core;
using UnityEngine;

namespace Descending.Gui.Party_Window
{
    public class AbilitiesPanel : MonoBehaviour
    {
        [SerializeField] private GameObject _abilityWidgetPrefab = null;
        [SerializeField] private Transform _powersParent = null;
        [SerializeField] private Transform _spellsParent = null;

        [SerializeField] private List<AbilityWidget> _powerWidgets = null;
        [SerializeField] private List<AbilityWidget> _spellWidgets = null;
        
        public void Setup()
        {
            
        }

        public void SelectHero(Hero hero)
        {
            _powersParent.ClearTransform();
            _powerWidgets.Clear();
            
            for (int i = 0; i < hero.Abilities.MemorizedPowers.Count; i++)
            {
                if(hero.Abilities.MemorizedPowers[i] != null)
                {
                    GameObject clone = Instantiate(_abilityWidgetPrefab, _powersParent);
                    AbilityWidget widget = clone.GetComponent<AbilityWidget>();
                    widget.SetAbility(hero.Abilities.MemorizedPowers[i]);
                    _powerWidgets.Add(widget);
                }
            }
            
            _spellsParent.ClearTransform();
            _spellWidgets.Clear();
            
            for (int i = 0; i < hero.Abilities.MemorizedSpells.Count; i++)
            {
                if(hero.Abilities.MemorizedSpells[i] != null)
                {
                    GameObject clone = Instantiate(_abilityWidgetPrefab, _spellsParent);
                    AbilityWidget widget = clone.GetComponent<AbilityWidget>();
                    widget.SetAbility(hero.Abilities.MemorizedSpells[i]);
                    _spellWidgets.Add(widget);
                }
            }
        }
    }
}