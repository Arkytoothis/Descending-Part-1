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
        [SerializeField] private RawImage _portrait = null;
        [SerializeField] private Color _selectedColor = Color.blue;
        
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
        
        public override void Select()
        {
            if (_hero != null)
            {
                _border.color = _selectedColor;
                _selected = true;
            }
        }

        public override void Deselect()
        {
            _border.color = _baseColor;
            _selected = false;
        }

        public override void Highlight()
        {
            _border.color = _hoverColor;
        }

        public override void Unhighlight()
        {
            if (_selected == true)
            {
                _border.color = _selectedColor;
            }
            else
            {
                _border.color = _baseColor;
            }
        }
    }
}
