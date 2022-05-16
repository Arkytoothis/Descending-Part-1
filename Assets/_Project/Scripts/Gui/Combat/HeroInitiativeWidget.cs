using System.Collections;
using System.Collections.Generic;
using Descending.Characters;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Descending.Gui.Combat
{
    public class HeroInitiativeWidget : InitiativeWidget, IPointerClickHandler
    {
        [SerializeField] protected RawImage _portrait = null;
        
        private Hero _hero = null;
        private int _initiativeRoll = 0;
        
        public void SetHero(int index, Hero hero, int initiativeRoll)
        {
            _index = index;
            _hero = hero;
            _initiativeRoll = initiativeRoll;
            _nameLabel.text = _hero.HeroData.Name.ShortName;

            if (_hero.Portrait != null)
            {
                _portrait.texture = _hero.Portrait.RtClose;
            }
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            
        }
    }
}
