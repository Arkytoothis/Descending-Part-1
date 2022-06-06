using System.Collections;
using System.Collections.Generic;
using Descending.Characters;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Descending.Gui.Party_Window
{
    public class PartyWidget : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private RawImage _portrait = null;
        [SerializeField] private TMP_Text _nameLabel = null;
        [SerializeField] private TMP_Text _detailsLabel = null;
        [SerializeField] private Image _border = null;
        [SerializeField] private Color _selectedColor = Color.white;
        [SerializeField] private Color _deselectedColor = Color.white;

        private PartyWindow _partyWindow = null;
        private Hero _hero = null;
        
        public void DisplayHero(PartyWindow window, Hero hero)
        {
            _hero = hero;
            _partyWindow = window;
            _nameLabel.text = hero.HeroData.Name.ShortName;
            _detailsLabel.SetText("Level " + hero.HeroData.Level + " " + hero.HeroData.Gender + " " + hero.HeroData.RaceKey + " " + hero.HeroData.ProfessionKey);

            if (hero.Portrait != null)
            {
                _portrait.texture = hero.Portrait.RtClose;
            }
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            _partyWindow.SelectHero(_hero);
        }

        public void Select()
        {
            _border.color = _selectedColor;
        }

        public void Deselect()
        {
            _border.color = _deselectedColor;
        }
    }
}
