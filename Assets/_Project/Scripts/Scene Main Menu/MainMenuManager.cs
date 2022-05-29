using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Descending.Core;
using Descending.Equipment;
using Descending.Scene_MainMenu.Gui;
using ScriptableObjectArchitecture;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Descending.Scene_MainMenu
{
    public enum MainMenuModes { Menu, New_Game, Load_Game, Options, Number, None }
    
    public class MainMenuManager : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera _menuCamera = null;
        [SerializeField] private CinemachineVirtualCamera _newGameCamera = null;
        [SerializeField] private CinemachineVirtualCamera _loadGameCamera = null;
        [SerializeField] private CinemachineVirtualCamera _optionsCamera = null;
        
        [SerializeField] private Database _database = null;
        [SerializeField] private PartyManager _partyManager = null;
        [SerializeField] private GameObject _guiPrefab = null;

        [SerializeField] private PartyManagerEvent onSyncParty = null;
        
        private GuiManager _gui = null;
        
        private void Awake()
        {
            _database.Setup();
            ItemGenerator.Setup();
        }

        private void Start()
        {
            SpawnGui();
            _partyManager.Setup();
            GenerateParty(true);
            SetMode(MainMenuModes.Menu);
        }

        public void OnSetMenuMode(int mode)
        {
            SetMode((MainMenuModes)mode);
        }
        
        private void SetMode(MainMenuModes mode)
        {
            _menuCamera.enabled = false;
            _newGameCamera.enabled = false;
            _loadGameCamera.enabled = false;
            _optionsCamera.enabled = false;
            
            switch (mode)
            {
                case MainMenuModes.Menu:
                    _menuCamera.enabled = true;
                    break;
                case MainMenuModes.New_Game:
                    _newGameCamera.enabled = true;
                    break;
                case MainMenuModes.Load_Game:
                    _loadGameCamera.enabled = true;
                    break;
                case MainMenuModes.Options:
                    _optionsCamera.enabled = true;
                    break;
                default:
                    break;
            }
        }
        
        private void SpawnGui()
        {
            GameObject clone = Instantiate(_guiPrefab, null);
            _gui = clone.GetComponent<GuiManager>();
            _gui.Setup();
        }

        public void GenerateParty(bool b)
        {
            _partyManager.GenerateParty();
            SyncParty();
        }

        public void GenerateFavoriteParty(bool b)
        {
            _partyManager.GenerateFavoriteParty();
            SyncParty();
        }

        public void StartGame(bool b)
        {
            Debug.Log("Starting Game");
            _partyManager.Save();
            SceneManager.LoadScene((int)GameScenes.Overworld);
        }

        private void SyncParty()
        {
            onSyncParty.Invoke(_partyManager);
        }
    } 
}