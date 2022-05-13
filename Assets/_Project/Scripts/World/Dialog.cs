using System;
using System.Collections;
using System.Collections.Generic;
using ScriptableObjectArchitecture;
using UnityEngine;

namespace Descending.World
{
    public class Dialog : MonoBehaviour
    {
        [SerializeField] private DialogEvent onRegisterDialog = null;
        
        private bool _isActive = false;
        public bool IsActive => _isActive;

        private void Awake()
        {
            onRegisterDialog.Invoke(this);
        }

        public void SetActive(bool active)
        {
            _isActive = active;
        }
    }
}
