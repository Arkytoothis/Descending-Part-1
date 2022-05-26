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
            
            foreach (var characteristicKvp in hero.Attributes.Characteristics)
            {
                characteristicsNames += characteristicKvp.Value.Key + "\n";
                characteristicsValues += characteristicKvp.Value.Maximum + "\n";
            }
            
            _characteristicsNamesLabel.SetText(characteristicsNames);
            _characteristicsValuesLabel.SetText(characteristicsValues);
            
            foreach (var vitalKvp in hero.Attributes.Vitals)
            {
                vitalsNames += vitalKvp.Value.Key + "\n";
                vitalsValues += vitalKvp.Value.Maximum + "\n";
            }
            
            _vitalsNamesLabel.SetText(vitalsNames);
            _vitalsValuesLabel.SetText(vitalsValues);
        }
    }
}