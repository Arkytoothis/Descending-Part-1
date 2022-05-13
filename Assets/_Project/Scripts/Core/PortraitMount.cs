using System.Collections;
using System.Collections.Generic;
using Descending.Attributes;
using Descending.Characters;
using UnityEngine;
using UnityEngine.Serialization;

namespace Descending.Core
{
    [System.Serializable]
    public class PortraitMount : MonoBehaviour
    {
        [SerializeField] private Transform _modelMount = null;
        [SerializeField] private GameObject _model = null;
        [SerializeField] private Camera _camClose = null;
        [SerializeField] private Camera _camFar = null;

        [SerializeField] RenderTexture _rtClose = null;
        [SerializeField] RenderTexture _rtFar = null;

        public RenderTexture RtClose { get => _rtClose; }
        public RenderTexture RtFar { get => _rtFar; }
        public GameObject Model { get => _model; }

        public void Setup(Hero hero)
        {
            _rtClose = new RenderTexture(256, 256, 32);
            _camClose.targetTexture = _rtClose;
            _rtFar = new RenderTexture(750, 920, 32);
            _camFar.targetTexture = _rtFar;

            SetModel(hero);
            StartCoroutine(RefreshWithDelay());
            DisableFarCamera();
        }

        public void SetModel(Hero hero)
        {
            if (hero != null && hero.PortraitModel != null)
            {
                _model = hero.PortraitModel;
        
                hero.SetPortrait(this);
                hero.PortraitModel.transform.SetParent(_modelMount, false);
                StartCoroutine(RefreshWithDelay());
            }
        }

        public void DisableCloseCamera()
        {
            _camClose.gameObject.SetActive(false);
        }

        public void DisableFarCamera()
        {
            _camFar.gameObject.SetActive(false);
        }

        public void EnableCloseCamera()
        {
            _camClose.gameObject.SetActive(true);
        }

        public void EnableFarCamera()
        {
            _camFar.gameObject.SetActive(true);
        }

        public RenderTexture GetCloseRt()
        {
            Refresh();
            return _camClose.targetTexture;
        }

        public RenderTexture GetFarRt()
        {
            return _camFar.targetTexture;
        }

        public void ClearMount()
        {
            _modelMount.ClearTransform();
            _model = null;
        }

        public void Refresh()
        {
            EnableCloseCamera();
            DisableCloseCamera();
        }

        public void RefreshFarCam()
        {
            StartCoroutine(RefreshWithDelayFar());
        }

        private IEnumerator RefreshWithDelay()
        {
            EnableCloseCamera();

            yield return new WaitForSeconds(0.1f);
            
            DisableCloseCamera();
        }

        private IEnumerator RefreshWithDelayFar()
        {
            EnableFarCamera();

            yield return new WaitForSeconds(0.1f);
            
            DisableFarCamera();
        }
    }
}