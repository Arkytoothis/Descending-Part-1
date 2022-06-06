using System;
using System.Collections;
using System.Collections.Generic;
using Descending.Core;
using Descending.Interactables;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Descending.Scene_Overworld_FP
{
    public class WorldRaycaster : MonoBehaviour
    {
        [SerializeField] private LayerMask _interactableMask = new LayerMask();
        [SerializeField] private Image _crosshair = null;
        [SerializeField] private float _interactableDistance = 10f;
        [SerializeField] private List<Texture2D> _cursorTextures = null;
        [SerializeField] private List<Sprite> _crosshairSprites = null;

        private bool _raycastEnabled = true;
        private Camera _camera = null;
        
        private void Start()
        {
            _camera = Camera.main;
        }
        
        private void Update()
        {
            if (_raycastEnabled == false) return;
            if (EventSystem.current.IsPointerOverGameObject() == true)
            {
                Cursor.SetCursor(_cursorTextures[(int)CursorTypes.Gui], Vector2.zero, CursorMode.Auto);
                return;
            }
            
            // if (Utilities.IsMouseInWindow() == false)
            // {
            //     Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
            //     return;
            // }

            if (RaycastForInteractable(GetRay()) == true) return;

            Cursor.SetCursor(_cursorTextures[(int)CursorTypes.Gui], Vector2.zero, CursorMode.Auto);
            _crosshair.sprite = _crosshairSprites[(int) CrosshairTypes.Default];
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
    }
}