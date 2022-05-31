using System.Collections;
using System.Collections.Generic;
using Descending.Enemies;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Descending.Gui.Combat
{
    public class EnemyInitiativeWidget : InitiativeWidget, IPointerClickHandler
    {
        [SerializeField] protected Image _portrait = null;
        [SerializeField] private Color _selectedColor = Color.blue;
        
        private Enemy _enemy = null;
        private int _initiativeRoll = 0;
        
        public void SetEnemy(int index, Enemy enemy, int initiativeRoll)
        {
            _index = index;
            _enemy = enemy;
            _initiativeRoll = initiativeRoll;
            _nameLabel.text = _enemy.EnemyDefinition.Name;
            _portrait.sprite = _enemy.EnemyDefinition.Icon;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            
        }

        public override void Select()
        {
            if (_enemy != null)
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
