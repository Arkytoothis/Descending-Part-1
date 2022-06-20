using System.Collections;
using System.Collections.Generic;
using Descending.Core;
using ScriptableObjectArchitecture;
using UnityEngine;

namespace Descending.Scene_MainMenu.Gui
{
    public class GuiManager : MonoBehaviour
    {
        [SerializeField] private GameObject _menuPanelPrefab = null;
        [SerializeField] private GameObject _partyPanelPrefab = null;
        
        [SerializeField] private IntEvent onSetMenuMode = null;
        
        private MenuPanel _menuPanel = null;
        private PartyPanel _partyPanel = null;
        
        public void Setup()
        {
            SpawnMenuPanel();
            SpawnPartyPanel();
        }

        public void NewGameButtonClicked()
        {
            onSetMenuMode.Invoke((int)MainMenuModes.New_Game);
            _partyPanel.Show();
        }

        public void ContinueButtonClicked()
        {
            onSetMenuMode.Invoke((int)MainMenuModes.Load_Game);
            _partyPanel.Hide();
        }

        public void LoadGameButtonClicked()
        {
            onSetMenuMode.Invoke((int)MainMenuModes.Load_Game);
            _partyPanel.Hide();
        }

        public void OptionsButtonClicked()
        {
            onSetMenuMode.Invoke((int)MainMenuModes.Options);
            _partyPanel.Hide();
        }

        public void ExitButtonClicked()
        {
            Utilities.Exit();
        }

        private void SpawnMenuPanel()
        {
            GameObject clone = Instantiate(_menuPanelPrefab, transform);
            _menuPanel = clone.GetComponent<MenuPanel>();
            _menuPanel.Setup(this);
        }

        private void SpawnPartyPanel()
        {
            GameObject clone = Instantiate(_partyPanelPrefab, transform);
            _partyPanel = clone.GetComponent<PartyPanel>();
            _partyPanel.Setup();
        }
    }
}