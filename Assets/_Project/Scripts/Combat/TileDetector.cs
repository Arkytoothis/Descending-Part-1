using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Descending.Combat
{
    public class TileDetector : MonoBehaviour
    {
        [SerializeField] private LayerMask _tileMask = new LayerMask();

        private bool _raycastEnabled = true;
        private Camera _camera = null;
        
        private void Start()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            Debug.DrawRay(new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), Vector3.down, Color.red);
        }

        public CombatTile RaycastForTile()
        {
            if (_raycastEnabled == false) return null;

            CombatTile tile = null;
            Vector3 startPosition = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
            Ray ray = new Ray(startPosition, Vector3.down);
            if (Physics.Raycast(ray, out RaycastHit hit, 100f, _tileMask))
            {
                tile = hit.collider.gameObject.GetComponent<CombatTile>();
            }

            return tile;
        }

        private Ray GetRay()
        {
            return _camera.ScreenPointToRay(Input.mousePosition);
        }
    }
}