using System.Collections;
using System.Collections.Generic;
using Descending.Core;
using ScriptableObjectArchitecture;
using UnityEngine;

namespace Descending.Gui
{
    public class PauseWindow : GameWindow
    {
        [SerializeField] private LookModesEvent onSetLookMode = null;
        [SerializeField] private BoolEvent onPartyLookEnabled = null;
        [SerializeField] private BoolEvent onPartyMovementEnabled = null;
        [SerializeField] private BoolEvent onSetPauseWindowOpenState = null;
        
        public override void Setup()
        {
            Close();
        }

        public override void Open()
        {
            _isOpen = true;
            onSetPauseWindowOpenState.Invoke(_isOpen);
            _container.SetActive(true);
            onSetLookMode.Invoke(LookModes.Cursor);
            onPartyLookEnabled.Invoke(false);
            onPartyMovementEnabled.Invoke(false);
        }

        public override void Close()
        {
            _isOpen = false;
            onSetPauseWindowOpenState.Invoke(_isOpen);
            _container.SetActive(false);
            onSetLookMode.Invoke(LookModes.Look);
            onPartyLookEnabled.Invoke(true);
            onPartyMovementEnabled.Invoke(true);
        }

        public void ResumeButtonClick()
        {
            Close();
        }

        public void SaveButtonClick()
        {
            Close();
        }

        public void LoadButtonClick()
        {
            Close();
        }

        public void OptionsButtonClick()
        {
            Close();
        }

        public void MainMenuButtonClick()
        {
            Close();
        }

        public void ExitButtonClick()
        {
            Utilities.Exit();
        }
    }
}
