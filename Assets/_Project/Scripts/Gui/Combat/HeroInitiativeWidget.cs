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
        private int _initiativeIndex = 0;
        
        public void SetHero(int index, Hero hero, int initiativeIndex, int initiativeRoll)
        {
            _index = index;
            _hero = hero;
            _initiativeRoll = initiativeRoll;
            _initiativeIndex = initiativeIndex;
            _nameLabel.text = _hero.HeroData.Name.FirstName;
            _initiativeLabel.text = initiativeIndex + " - " + initiativeRoll;
            _lifeBar.SetValues(hero.Attributes.GetVital("Life").Current, hero.Attributes.GetVital("Life").Maximum, false);
            
            if (_hero.Portrait != null)
            {
                _portrait.texture = _hero.Portrait.RtClose;
            }
            
            Unhighlight();
            Deselect();
        }

        public void SyncData()
        {
            _lifeBar.SetValues(_hero.Attributes.GetVital("Life").Current, _hero.Attributes.GetVital("Life").Maximum, false);
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
