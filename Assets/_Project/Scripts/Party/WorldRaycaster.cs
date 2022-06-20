using System;
using System.Collections;
using System.Collections.Generic;
using Descending.Abilities;
using Descending.Core;
using Descending.Enemies;
using Descending.Interactables;
using ScriptableObjectArchitecture;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Descending.Party
{
    public enum RaycastModes { World, Combat, Ability, Number, None }
    
    public class WorldRaycaster : MonoBehaviour
    {
        [SerializeField] private LayerMask _interactableMask = new LayerMask();
        [SerializeField] private LayerMask _enemyMask = new LayerMask();
        [SerializeField] private Image _crosshair = null;
        [SerializeField] private float _interactableDistance = 10f;
        [SerializeField] private float _enemyDistance = 10f;
        [SerializeField] private List<Texture2D> _cursorTextures = null;
        [SerializeField] private List<Sprite> _crosshairSprites = null;

        [SerializeField] private EnemyEvent onEnemyClicked_Left = null;
        [SerializeField] private EnemyEvent onEnemyClicked_Right = null;
        
        private bool _raycastEnabled = true;
        private bool _enemyClickEnabled = false;
        private Camera _camera = null;
        private RaycastModes _mode = RaycastModes.None;
        private Ability _currentAbility = null;
        
        private void Start()
        {
            _camera = Camera.main;
            _mode = RaycastModes.World;
        }

        private void Update()
        {
            if (_raycastEnabled == false) return;
            if (EventSystem.current.IsPointerOverGameObject() == true)
            {
                Cursor.SetCursor(_cursorTextures[(int) CursorTypes.Gui], Vector2.zero, CursorMode.Auto);
                return;
            }

            if (Utilities.IsMouseInWindow() == false)
            {
                Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                return;
            }

            if (Input.GetMouseButtonDown(1) && _mode == RaycastModes.Ability)
            {
                _mode = RaycastModes.Combat;
            }
            
            if (_mode == RaycastModes.World || _mode == RaycastModes.Combat)
            {
                if (RaycastForInteractable(GetRay()) == true) return;
                if (RaycastForEnemy(GetRay()) == true) return;

                Cursor.SetCursor(_cursorTextures[(int) CursorTypes.Gui], Vector2.zero, CursorMode.Auto);
                _crosshair.sprite = _crosshairSprites[(int) CrosshairTypes.Default];
            }
            else
            {
                if (RaycastForAbilityTarget(GetRay()) == true) return;
            }
        }

        bool RaycastForInteractable(Ray ray)
        {
            if (Physics.Raycast(ray, out RaycastHit hit, _interactableDistance, _interactableMask))
            {
                Interactable interactable = hit.collider.gameObject.GetComponentInParent<Interactable>();

                if (interactable != null)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        interactable.Interact();
                    }

                    Cursor.SetCursor(_cursorTextures[(int) CursorTypes.Interact], Vector2.zero, CursorMode.Auto);
                    _crosshair.sprite = _crosshairSprites[(int) CrosshairTypes.Interact];
                    return true;
                }
            }

            return false;
        }
        
        bool RaycastForEnemy(Ray ray)
        {
            if (Physics.Raycast(ray, out RaycastHit hit, _enemyDistance, _enemyMask))
            {
                Enemy enemy = hit.collider.gameObject.GetComponent<Enemy>();

                if (enemy != null)
                {
                    Cursor.SetCursor(_cursorTextures[(int) CursorTypes.Enemy], Vector2.zero, CursorMode.Auto);
                    _crosshair.sprite = _crosshairSprites[(int) CrosshairTypes.Enemy];

                    if(_enemyClickEnabled == true && Input.GetMouseButtonDown(0))
                    {
                        onEnemyClicked_Left.Invoke(enemy);
                    }
                    // else if (_enemyClickEnabled == true && Input.GetMouseButtonDown(1))
                    // {
                    //     onEnemyClicked_Right.Invoke(enemy);
                    // }
                    
                    return true;
                }
            }

            return false;
        }

        bool RaycastForAbilityTarget(Ray ray)
        {
            if (_currentAbility != null && Physics.Raycast(ray, out RaycastHit hit, 100f))
            {
                if (_currentAbility.Definition.Details.TargetType == TargetTypes.Enemy)
                {
                    Enemy enemy = hit.collider.gameObject.GetComponent<Enemy>();

                    if (enemy != null)
                    {
                        Cursor.SetCursor(_cursorTextures[(int) CursorTypes.Ability_Valid], Vector2.zero, CursorMode.Auto);

                        if (Input.GetMouseButtonDown(0))
                        {
                            Debug.Log("Using " + _currentAbility.Definition.Details.Name + " on " + enemy.GetName());
                        }

                        return true;
                    }
                }
                //     Cursor.SetCursor(_cursorTextures[(int) CursorTypes.Abil], Vector2.zero, CursorMode.Auto);
                //     _crosshair.sprite = _crosshairSprites[(int) CrosshairTypes.Enemy];
                //
                //     if(_enemyClickEnabled == true && Input.GetMouseButtonDown(0))
                //     {
                //         onEnemyClicked_Left.Invoke(enemy);
                //     }
                //     else if (_enemyClickEnabled == true && Input.GetMouseButtonDown(1))
                //     {
                //         onEnemyClicked_Right.Invoke(enemy);
                //     }
                //    
            }

            Cursor.SetCursor(_cursorTextures[(int) CursorTypes.Ability_Invalid], Vector2.zero, CursorMode.Auto);
            
            return false;
        }

        private Ray GetRay()
        {
            return _camera.ScreenPointToRay(Input.mousePosition);
        }

        public void EnableRaycast()
        {
            _raycastEnabled = true;
        }

        public void DisableRaycast()
        {
            _raycastEnabled = false;
        }

        public void SetCrosshairActive(bool active)
        {
            _crosshair.enabled = active;
        }

        public void OnSetEnemyClickEnabled(bool enable)
        {
            _enemyClickEnabled = enable;
        }

        public void SetRaycastMode(RaycastModes mode)
        {
            _mode = mode;
        }

        public void SetAbility(Ability ability)
        {
            _currentAbility = ability;
        }
    }
}