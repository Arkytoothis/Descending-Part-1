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
        [SerializeField] private TMP_Text _nameLabel = null;
        [SerializeField] private RawImage _portrait = null;

        private PartyWindow _partyWindow = null;
        private Hero _hero = null;
        
        public void DisplayHero(PartyWindow window, Hero hero)
        {
            _hero = hero;
            _partyWindow = window;
            _nameLabel.text = hero.HeroData.Name.ShortName;

            if (hero.Portrait != null)
            {
                _portrait.texture = hero.Portrait.RtClose;
            }
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            _partyWindow.SelectHero(_hero);
        }
    }
}
