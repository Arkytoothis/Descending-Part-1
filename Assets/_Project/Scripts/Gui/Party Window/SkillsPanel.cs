using System.Collections;
using System.Collections.Generic;
using Descending.Attributes;
using Descending.Characters;
using Descending.Core;
using Descending.Gui.PcViewer;
using UnityEngine;

namespace Descending.Gui.Party_Window
{
    public class SkillsPanel : MonoBehaviour
    {
        [SerializeField] private GameObject _skillWidgetPrefab = null;
        [SerializeField] private Transform _skillsWidgetsParent = null;

        private SkillWidgetDictionary _skillWidgets = new SkillWidgetDictionary();

        public void Setup()
        {
            
        }

        public void SelectHero(Hero hero)
        {
            _skillWidgets.Clear();
            _skillsWidgetsParent.ClearTransform();
            
            foreach (var skillKvp in hero.Skills.Skills)
            {
                GameObject clone = Instantiate(_skillWidgetPrefab, _skillsWidgetsParent);
                SkillWidget widget = clone.GetComponent<SkillWidget>();
                widget.SetSkill(skillKvp.Value);
                
                _skillWidgets.Add(skillKvp.Key, widget);
            }
        }
    }
}