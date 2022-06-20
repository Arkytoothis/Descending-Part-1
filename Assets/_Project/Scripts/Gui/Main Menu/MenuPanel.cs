using System.Collections;
using System.Collections.Generic;
using Descending.Core;
using ScriptableObjectArchitecture;
using UnityEngine;

namespace  Descending.Scene_MainMenu.Gui
{
    public class MenuPanel : MonoBehaviour
    {
        [SerializeField] private GameObject _container = null;

        private GuiManager _guiManager = null;
        
        public void Setup(GuiManager guiManager)
        {
            _guiManager = guiManager;
            Show();
        }

        public void Show()
        {
            _container.SetActive(true);
        }

        public void Hide()
        {
            _container.SetActive(false);
        }

        public void NewGameButtonClick()
        {
            _guiManager.NewGameButtonClicked();
        }

        public void ContinueButtonClick()
        {
            _guiManager.ContinueButtonClicked();
        }

        public void LoadGameButtonClick()
        {
            _guiManager.LoadGameButtonClicked();
        }

        public void OptionsButtonClick()
        {
            _guiManager.OptionsButtonClicked();
        }

        public void ExitButtonClick()
        {
            _guiManager.ExitButtonClicked();
        }
    }
}
