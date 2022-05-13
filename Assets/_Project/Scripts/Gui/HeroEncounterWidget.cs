using System.Collections;
using System.Collections.Generic;
using Descending.Characters;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Descending.Gui
{
    public class HeroEncounterWidget : MonoBehaviour
    {
        [SerializeField] private RawImage _portrait = null;
        [SerializeField] private TMP_Text _nameLabel = null;
        [SerializeField] private TMP_Text _detailsLabel = null;

        public void Setup(Hero hero)
        {
            _portrait.texture = hero.Portrait.RtClose;
            _nameLabel.SetText(hero.GetName());
            _detailsLabel.SetText("Lvl " + hero.HeroData.Level + " " + hero.HeroData.RaceKey);
        }
    }
}
