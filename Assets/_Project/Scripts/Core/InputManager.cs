using System;
using System.Collections;
using System.Collections.Generic;
using Descending.Party;
using ScriptableObjectArchitecture;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Descending.Core
{
    public class InputManager : MonoBehaviour
    {
        [SerializeField] private BoolEvent onToggleMenuWindow = null;
        [SerializeField] private BoolEvent onTogglePartyWindow = null;
        //[SerializeField] private LookModesEvent onSetLookMode = null;

        public void OnTogglePartyWindow(InputAction.CallbackContext value)
        {
            if (value.performed)
            {
                Debug.Log("Toggling Party Window");
                onTogglePartyWindow.Invoke(true);
            }
        }

        public void OnTogglePauseWindow(InputAction.CallbackContext value)
        {
            if (value.performed)
            {
                Debug.Log("Toggling Pause Window");
                onToggleMenuWindow.Invoke(true);
            }
        }
    }
}
