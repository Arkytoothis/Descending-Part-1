using System.Collections;
using System.Collections.Generic;
using Descending.Characters;
using TMPro;
using UnityEngine;

namespace Descending.Gui.Party_Window
{
    public class DetailsPanel : MonoBehaviour
    {
        [SerializeField] private TMP_Text _nameLabel = null;
        [SerializeField] private TMP_Text _detailsLabel = null;
        [SerializeField] private VitalBar _experienceBar = null;

        public void Setup()
        {
            
        }

        public void SelectHero(Hero hero)
        {
            _nameLabel.SetText(hero.HeroData.Name.FullName);
            _detailsLabel.SetText("Level " + hero.HeroData.Level + " " + hero.HeroData.Gender + " " + hero.HeroData.RaceKey + " " + hero.HeroData.ProfessionKey);
            _experienceBar.SetValues(hero.HeroData.Experience, hero.HeroData.ExpToNextLevel, true);
        }
    }
}