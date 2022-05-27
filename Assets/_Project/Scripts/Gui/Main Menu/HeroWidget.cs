using System.Collections;
using System.Collections.Generic;
using Descending.Characters;
using TMPro;
using UnityEngine;

namespace Descending.Scene_MainMenu.Gui
{
    public class HeroWidget : MonoBehaviour
    {
        [SerializeField] private TMP_Text _nameLabel = null;
        [SerializeField] private TMP_Text _detailsLabel = null;
        [SerializeField] private TMP_Text _characteristicsNamesLabel = null;
        [SerializeField] private TMP_Text _characteristicsValuesLabel = null;
        [SerializeField] private TMP_Text _vitalsNamesLabel = null;
        [SerializeField] private TMP_Text _vitalsValuesLabel = null;

        public void SetHero(Hero hero)
        {
            _nameLabel.text = hero.HeroData.Name.ShortName;
            _detailsLabel.text = "Level " + hero.HeroData.Level + " " + hero.HeroData.Gender + " " + hero.HeroData.RaceKey + " " + hero.HeroData.ProfessionKey;

            string characteristicsNames = "";
            string characteristicsValues = "";
            string vitalsNames = "";
            string vitalsValues = "";
            
            characteristicsNames += "Might\n";
            characteristicsValues += hero.Attributes.Characteristics["Might"].Maximum + "\n";
            characteristicsNames += "Finesse" + "\n";
            characteristicsValues += hero.Attributes.Characteristics["Finesse"].Maximum + "\n";
            characteristicsNames += "Endurance" + "\n";
            characteristicsValues += hero.Attributes.Characteristics["Endurance"].Maximum + "\n";
            characteristicsNames += "Intellect" + "\n";
            characteristicsValues += hero.Attributes.Characteristics["Intellect"].Maximum + "\n";
            characteristicsNames += "Spirit" + "\n";
            characteristicsValues += hero.Attributes.Characteristics["Spirit"].Maximum + "\n";
            characteristicsNames += "Perception" + "\n";
            characteristicsValues += hero.Attributes.Characteristics["Perception"].Maximum + "\n";
            
            _characteristicsNamesLabel.SetText(characteristicsNames);
            _characteristicsValuesLabel.SetText(characteristicsValues);

            vitalsNames += "Armor\n";
            vitalsValues += hero.Attributes.Vitals["Armor"].Maximum + "\n";
            vitalsNames += "Life\n";
            vitalsValues += hero.Attributes.Vitals["Life"].Maximum + "\n";
            vitalsNames += "Stamina\n";
            vitalsValues += hero.Attributes.Vitals["Stamina"].Maximum + "\n";
            vitalsNames += "Magic\n";
            vitalsValues += hero.Attributes.Vitals["Magic"].Maximum + "\n";
            
            _vitalsNamesLabel.SetText(vitalsNames);
            _vitalsValuesLabel.SetText(vitalsValues);
        }
    }
}