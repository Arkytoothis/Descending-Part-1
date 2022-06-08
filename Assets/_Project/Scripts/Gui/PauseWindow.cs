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
        
        public override void Setup()
        {
            Close();
        }

        public override void Open()
        {
            Time.timeScale = 0;
            _isOpen = true;
            _container.SetActive(true);
        }

        public override void Close()
        {
            Time.timeScale = 1;
            _isOpen = false;
            _container.SetActive(false);
            onSetLookMode.Invoke(LookModes.Look);
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
