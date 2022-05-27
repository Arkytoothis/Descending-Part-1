using System;
using System.Collections;
using System.Collections.Generic;
using Descending.Core;
using Descending.Equipment;
using Descending.Scene_MainMenu.Gui;
using ScriptableObjectArchitecture;
using UnityEngine;

namespace Descending.Scene_MainMenu
{
    public class MainMenuManager : MonoBehaviour
    {
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
        }

        public void Exit(bool b)
        {
            Debug.Log("Exiting");
        }

        private void SyncParty()
        {
            onSyncParty.Invoke(_partyManager);
        }
    } 
}