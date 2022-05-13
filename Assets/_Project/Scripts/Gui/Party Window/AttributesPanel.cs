using System.Collections;
using System.Collections.Generic;
using Descending.Attributes;
using Descending.Characters;
using Descending.Core;
using UnityEngine;

namespace Descending.Gui.Party_Window
{
    public class AttributesPanel : MonoBehaviour
    {
        [SerializeField] private AttributeWidgetDictionary _attributeWidgets = null;
        [SerializeField] private VitalWidgetDictionary _vitalWidgets = null;
        [SerializeField] private AttributeWidgetDictionary _statisticWidgets = null;

        public void Setup()
        {
            
        }

        public void SelectHero(Hero hero)
        {
            DisplayAttribute(hero.Attributes.GetAttribute("Might"));
            DisplayAttribute(hero.Attributes.GetAttribute("Finesse"));
            DisplayAttribute(hero.Attributes.GetAttribute("Endurance"));
            DisplayAttribute(hero.Attributes.GetAttribute("Intellect"));
            DisplayAttribute(hero.Attributes.GetAttribute("Spirit"));
            DisplayAttribute(hero.Attributes.GetAttribute("Perception"));
            
            DisplayVital(hero.Attributes.GetVital("Armor"));
            DisplayVital(hero.Attributes.GetVital("Life"));
            DisplayVital(hero.Attributes.GetVital("Stamina"));
            DisplayVital(hero.Attributes.GetVital("Magic"));
            
            DisplayStatisticPercentage(hero.Attributes.GetStatistic("Aim"));
            DisplayStatisticPercentage(hero.Attributes.GetStatistic("Attack"));
            DisplayStatisticPercentage(hero.Attributes.GetStatistic("Block"));
            DisplayStatisticPercentage(hero.Attributes.GetStatistic("Dodge"));
            DisplayStatisticPercentage(hero.Attributes.GetStatistic("Focus"));
            DisplayStatisticPercentage(hero.Attributes.GetStatistic("Willpower"));
            DisplayStatisticPoints(hero.Attributes.GetStatistic("Speed"));
        }

        private void DisplayAttribute(Attribute attribute)
        {
            _attributeWidgets[attribute.Key].SetAttribute(attribute);
        }

        private void DisplayVital(Attribute attribute)
        {
            _vitalWidgets[attribute.Key].SetVital(attribute, true);
        }

        private void DisplayStatisticPercentage(Attribute attribute)
        {
            _statisticWidgets[attribute.Key].SetStatisticPercentage(attribute);
        }

        private void DisplayStatisticPoints(Attribute attribute)
        {
            _statisticWidgets[attribute.Key].SetStatisticPoints(attribute);
        }
    }
}