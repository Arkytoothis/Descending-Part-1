using System.Collections;
using System.Collections.Generic;
using Descending.Enemies;
using ScriptableObjectArchitecture;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Descending.Gui.Combat
{
    public class EnemyInitiativeWidget : InitiativeWidget, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] protected Image _portrait = null;
        [SerializeField] private Color _selectedColor = Color.blue;
        
        [SerializeField] private IntEvent onHighlightEnemy_World = null;
        
        private Enemy _enemy = null;
        private int _initiativeRoll = 0;
        private int _initiativeIndex = 0;
        
        public void SetEnemy(int index, Enemy enemy, int initiativeIndex, int initiativeRoll)
        {
            _index = index;
            _enemy = enemy;
            _initiativeRoll = initiativeRoll;
            _initiativeIndex = initiativeIndex;
            _nameLabel.text = _enemy.EnemyDefinition.Name;
            _initiativeLabel.text = initiativeIndex + ", " + initiativeRoll;
            _portrait.sprite = _enemy.EnemyDefinition.Icon;
            _lifeBar.SetValues(enemy.Attributes.GetVital("Life").Current, enemy.Attributes.GetVital("Life").Maximum, false);
            
            Unhighlight();
            Deselect();
        }

        public void SyncData()
        {
            _lifeBar.SetValues(_enemy.Attributes.GetVital("Life").Current, _enemy.Attributes.GetVital("Life").Maximum, false);
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

        public void OnPointerEnter(PointerEventData eventData)
        {
            onHighlightEnemy_World.Invoke(_enemy.ListIndex);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            onHighlightEnemy_World.Invoke(-1);
        }
    }
}
