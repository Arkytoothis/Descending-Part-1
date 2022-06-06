using System;
using System.Collections;
using System.Collections.Generic;
using Descending.Combat;
using Descending.Core;
using ScriptableObjectArchitecture;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Descending
{
    public class CombatRaycaster : MonoBehaviour
    {
        [SerializeField] private LayerMask _tileMask = new LayerMask();
        [SerializeField] private LayerMask _heroMask = new LayerMask();
        [SerializeField] private List<Texture2D> _cursors = null;

        [SerializeField] private CombatTileEvent onMoveToTile = null;
        
        private bool _raycastEnabled = true;
        private Camera _camera = null;
        private CombatTile _currentTile = null;

        private void Start()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            if (_raycastEnabled == false) return;
            if (EventSystem.current.IsPointerOverGameObject() == true)
            {
                Cursor.SetCursor(_cursors[(int) CursorTypes.Gui], Vector2.zero, CursorMode.Auto);
                return;
            }

            if (Utilities.IsMouseInWindow() == false)
            {
                Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                return;
            }

            if (RaycastForTile(GetRay()) == true) return;
            if (RaycastForHero(GetRay()) == true) return;

            Cursor.SetCursor(_cursors[(int) CursorTypes.Gui], Vector2.zero, CursorMode.Auto);
        }

        bool RaycastForTile(Ray ray)
        {
            if (Physics.Raycast(ray, out RaycastHit hit, 1000f, _tileMask))
            {
                CombatTile tile = hit.collider.GetComponent<CombatTile>();
                if (tile == null) return false;
                
                _currentTile = tile;
        
                if (Input.GetMouseButtonDown(1))
                {
                    if (_currentTile.State == CombatTileStates.Hightlight_Move && _currentTile.Entity == null)
                    {
                        onMoveToTile.Invoke(_currentTile);
                    }
                }

                //Cursor.SetCursor(_cursors[(int) CursorTypes.Terrain], Vector2.zero, CursorMode.Auto);
                return true;
            }

            return false;
        }

        bool RaycastForHero(Ray ray)
        {
            if (Physics.Raycast(ray, out RaycastHit hit, 1000f, _heroMask))
            {
                if (Input.GetMouseButtonDown(1))
                {
                    Debug.Log(hit.collider.gameObject.name + " clicked");
                }

                //Cursor.SetCursor(_cursors[(int) CursorTypes.Terrain], Vector2.zero, CursorMode.Auto);
                return true;
            }

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
    }
}