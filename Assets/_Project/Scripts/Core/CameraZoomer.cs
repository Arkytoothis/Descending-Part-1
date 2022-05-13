using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

namespace Descending
{
    public class CameraZoomer : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera _camera = null;
        [SerializeField] private float _zoomSpeed = 100f;
        [SerializeField] private float _minZoom = 5f;
        [SerializeField] private float _maxZoom = 100f;
        [SerializeField] private float _startZoom = 20f;
        [SerializeField] private float _zOffset = 0.5f;

        private CinemachineTransposer _transposer = null;
        
        private void Awake()
        {
            _transposer = _camera.GetCinemachineComponent<CinemachineTransposer>();
            SetHeight(_startZoom);
            
        }

        private void Update()
        {
            float zoom = -Input.GetAxis("Mouse ScrollWheel") * _zoomSpeed * Time.unscaledDeltaTime;

            if (zoom == 0) return;
            
            Zoom(zoom);

            if (_transposer.m_FollowOffset.y < _minZoom)
            {
                SetHeight(_minZoom);
            }

            if (_transposer.m_FollowOffset.y > _maxZoom)
            {
                SetHeight(_maxZoom);
            }
        }

        private void Zoom(float zoom)
        {
            _transposer.m_FollowOffset = new Vector3(_transposer.m_FollowOffset.x, _transposer.m_FollowOffset.y + zoom, _transposer.m_FollowOffset.z - (zoom * _zOffset));
        }

        private void SetHeight(float height)
        {
            _transposer.m_FollowOffset = new Vector3(_transposer.m_FollowOffset.x, height,  -(height * _zOffset));
        }
    }
}