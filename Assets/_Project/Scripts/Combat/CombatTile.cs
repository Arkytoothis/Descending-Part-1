using System;
using System.Collections;
using System.Collections.Generic;
using Descending.Characters;
using Descending.Enemies;
using ScriptableObjectArchitecture;
using UnityEngine;
using UnityEngine.Serialization;

namespace Descending.Combat
{
    public enum CombatTileStates { Selected, Hightlight_Move, Highlight_Attack, Hightlight_Ability, Number, None }
    
    public class CombatTile : MonoBehaviour
    {
        [SerializeField] private int _x = -1;
        [SerializeField] private int _y = -1;
        [ColorUsage(true, true)] [SerializeField] private Color _baseColor = Color.white;
        [ColorUsage(true, true)] [SerializeField] private Color _hoverColor = Color.white;
        [ColorUsage(true, true)] [SerializeField] private Color _selectedHeroColor = Color.cyan;
        [ColorUsage(true, true)] [SerializeField] private Color _selectedEnemyColor = Color.red;
        [ColorUsage(true, true)] [SerializeField] private Color _highlightMoveColor = Color.yellow;
        [ColorUsage(true, true)] [SerializeField] private Color _highlightAttackColor = Color.red;
        [FormerlySerializedAs("_renderer")] [SerializeField] private MeshRenderer _borderRenderer = null;
        [SerializeField] private MeshRenderer _centerRenderer = null;

        [SerializeField] private CombatTileEvent onDisplayCombatTile = null;
        
        [SerializeField] private GameEntity _entity = null;
        [SerializeField] private CombatTileStates _state = CombatTileStates.None;
        
        public int X => _x;
        public int Y => _y;
        public GameEntity Entity => _entity;
        public CombatTileStates State => _state;

        public void Setup(int x, int y)
        {
            _x = x;
            _y = y;
        }

        private void OnMouseEnter()
        {
            Highlight();
        }

        private void OnMouseExit()
        {
            Unhighlight();
        }
        
        public void Highlight()
        {
            _borderRenderer.material.SetColor("_BaseColor", _hoverColor);
            onDisplayCombatTile.Invoke(this);
        }

        public void HighlightMove()
        {
            _centerRenderer.material.SetColor("_BaseColor", _highlightMoveColor);
            _state = CombatTileStates.Hightlight_Move;
        }

        public void HighlightAttack()
        {
            _centerRenderer.material.SetColor("_BaseColor", _highlightAttackColor);
            _state = CombatTileStates.Highlight_Attack;
        }

        public void Unhighlight()
        {
            if (_state == CombatTileStates.Selected && _entity.GetType() == typeof(Hero))
            {
                _borderRenderer.material.SetColor("_BaseColor", _selectedHeroColor);
            }
            else if (_state == CombatTileStates.Selected && _entity.GetType() == typeof(Enemy))
            {
                _borderRenderer.material.SetColor("_BaseColor", _selectedEnemyColor);
            }
            else if (_state == CombatTileStates.Hightlight_Move)
            {
                _borderRenderer.material.SetColor("_BaseColor", _baseColor);
            }
            else if (_state == CombatTileStates.Highlight_Attack)
            {
                _borderRenderer.material.SetColor("_BaseColor", _baseColor);
            }
            else if (_state == CombatTileStates.None)
            {
                _borderRenderer.material.SetColor("_BaseColor", _baseColor);
            }
            
            onDisplayCombatTile.Invoke(null);
        }

        public void SelectHero()
        {
            _borderRenderer.material.SetColor("_BaseColor", _selectedHeroColor);
            _state = CombatTileStates.Selected;
        }

        public void SelectEnemy()
        {
            _borderRenderer.material.SetColor("_BaseColor", _selectedEnemyColor);
            _state = CombatTileStates.Selected;
        }

        public void Deselect()
        {
            _borderRenderer.material.SetColor("_BaseColor", _baseColor);
            _state = CombatTileStates.None;
        }

        public void SetGameEntity(GameEntity entity)
        {
            _entity = entity;
        }

        public void Clear()
        {
            _borderRenderer.material.SetColor("_BaseColor", _baseColor);
            _centerRenderer.material.SetColor("_BaseColor", Color.clear);
            _state = CombatTileStates.None;
        }
    }
}