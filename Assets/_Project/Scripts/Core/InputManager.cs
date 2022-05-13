using System;
using System.Collections;
using System.Collections.Generic;
using Descending.Gui;
using UnityEngine;

namespace Descending.Core
{
    public class InputManager : MonoBehaviour
    {
        private WindowManager _windowManager = null;
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (_windowManager.IsAnyWindowOpen() == true)
                {
                    _windowManager.CLoseAll();
                }
                else if (_windowManager.IsWindowOpen((int) GameWindows.Pause) == false)
                {
                    _windowManager.OpenWindow((int) GameWindows.Pause);
                }
            }

            if (Input.GetKeyDown(KeyCode.C))
            {
                if (_windowManager.IsWindowOpen((int) GameWindows.Party) == true)
                {
                    _windowManager.CloseWindow((int) GameWindows.Party); 
                }
                else if (_windowManager.IsAnyWindowOpen() == true)
                {
                    _windowManager.CLoseAll();
                    _windowManager.OpenWindow((int) GameWindows.Party);
                }
                else
                {
                    _windowManager.OpenWindow((int) GameWindows.Party);
                }
            }
        }

        public void SetWindowManager(WindowManager windowManager)
        {
            _windowManager = windowManager;
        }
    }
}
