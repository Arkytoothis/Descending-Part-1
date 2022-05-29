using System.Collections;
using System.Collections.Generic;
using Descending.Core;
using ScriptableObjectArchitecture;
using UnityEngine;

namespace Descending.Scene_MainMenu.Gui
{
    public class GuiManager : MonoBehaviour
    {
        [SerializeField] private GameObject _partyPanelPrefab = null;
        
        [SerializeField] private IntEvent onSetMenuMode = null;
        
        private PartyPanel _partyPanel = null;
        
        public void Setup()
        {
            SpawnPartyPanel();
        }

        public void NewGame_ButtonClick()
        {
            onSetMenuMode.Invoke((int)MainMenuModes.New_Game);
            _partyPanel.Show();
        }

        public void LoadGame_ButtonClick()
        {
            onSetMenuMode.Invoke((int)MainMenuModes.Load_Game);
            _partyPanel.Hide();
        }

        public void Options_ButtonClick()
        {
            onSetMenuMode.Invoke((int)MainMenuModes.Options);
            _partyPanel.Hide();
        }

        public void Exit_ButtonClick()
        {
            Utilities.Exit();
        }

        private void SpawnPartyPanel()
        {
            GameObject clone = Instantiate(_partyPanelPrefab, transform);
            _partyPanel = clone.GetComponent<PartyPanel>();
            _partyPanel.Setup();
        }
    }
}