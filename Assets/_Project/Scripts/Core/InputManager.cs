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
        //[SerializeField] private bool _partyWindowOpen = false;
        //[SerializeField] private bool _pauseWindowOpen = false;
        //[SerializeField] private WorldRaycaster _worldRaycaster = null;
        
        [SerializeField] private BoolEvent onToggleMenuWindow = null;
        [SerializeField] private BoolEvent onTogglePartyWindow = null;
        //[SerializeField] private LookModesEvent onSetLookMode = null;

        public void OnTogglePartyWindow(InputAction.CallbackContext value)
        {
            if (value.performed)
            {
                Debug.Log("Toggling Party Window");
                onTogglePartyWindow.Invoke(true);
                // if (Cursor.lockState == CursorLockMode.None)
                // {
                //     SetModeLook();
                // }
                // else if (Cursor.lockState == CursorLockMode.Locked)
                // {
                //     SetModeCursor();
                // }
            }
        }

        public void OnTogglePauseWindow(InputAction.CallbackContext value)
        {
            if (value.performed)
            {
                Debug.Log("Toggling Pause Window");
                onToggleMenuWindow.Invoke(true);
                // if (Cursor.lockState == CursorLockMode.None)
                // {
                //     SetModeLook();
                // }
                // else if (Cursor.lockState == CursorLockMode.Locked)
                // {
                //     SetModeCursor();
                // }
            }
        }
        
        // private void SetModeCursor()
        // {
        //     onSetLookMode.Invoke(LookModes.Cursor);
        //     Cursor.lockState = CursorLockMode.None;
        //     Cursor.visible = true;
        //     _worldRaycaster.SetCrosshairActive(false);
        // }
        //
        // private void SetModeLook()
        // {
        //     onSetLookMode.Invoke(LookModes.Look);
        //     Cursor.lockState = CursorLockMode.Locked;
        //     Cursor.visible = false;
        //     _worldRaycaster.SetCrosshairActive(true);
        // }
    }
}
