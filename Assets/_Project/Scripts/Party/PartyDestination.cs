using System;
using System.Collections;
using System.Collections.Generic;
using Descending.Core;
using Descending.World;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

namespace Descending
{
    public class PartyDestination : MonoBehaviour
    {
        [SerializeField] private LayerMask _groundMask = new LayerMask();
        [FormerlySerializedAs("_buildingMask")] [SerializeField] private LayerMask _featureMask = new LayerMask();
        [SerializeField] private PartyMover _partyMover = null;
        //[SerializeField] private List<Texture2D> _cursors = null;

        private bool _raycastEnabled = true;
        private Camera _camera = null;
        
        private void Start()
        {
            _camera = Camera.main;
            _partyMover.SetPosition(transform.position);
        }
        
        private void Update()
        {
            if (_raycastEnabled == false) return;
            if (EventSystem.current.IsPointerOverGameObject() == true)
            {
                //Cursor.SetCursor(_cursors[(int)CursorTypes.Gui], Vector2.zero, CursorMode.Auto);
                return;
            }
            
            if (Utilities.IsMouseInWindow() == false)
            {
                Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                return;
            }

            if (RaycastForFeature(GetRay()) == true) return;
            if (RaycastForTerrain(GetRay()) == true) return;

            //Cursor.SetCursor(_cursors[(int)CursorTypes.Gui], Vector2.zero, CursorMode.Auto);
        }

        bool RaycastForTerrain(Ray ray)
        {
            if (Physics.Raycast(ray, out RaycastHit hit, 1000f, _groundMask))
            {
                if (Input.GetMouseButtonDown(1))
                { 
                    //Debug.Log(hit.collider.gameObject.name);
                    transform.position = hit.point;
                    _partyMover.MoveTo(hit.point);
                }
                
                return true;
            }

            return false;
        }
        
        bool RaycastForFeature(Ray ray)
        {
            if (Physics.Raycast(ray, out RaycastHit hit, 1000f, _featureMask))
            {
                if (Input.GetMouseButtonDown(1))
                {
                    Feature feature = hit.collider.gameObject.GetComponent<Feature>();
                    transform.position = feature.InteractionTransform.position;
                    _partyMover.MoveTo(feature.InteractionTransform.position);
                }
                
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