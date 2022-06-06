using System;
using System.Collections;
using System.Collections.Generic;
using Descending.Core;
using Descending.Scene_Overworld_FP.Gui;
using UnityEngine;

namespace Descending.Scene_Overworld_FP
{
    public class OverworldManager : MonoBehaviour
    {
        [SerializeField] private Database _database = null;
        [SerializeField] private GameObject _guiPrefab = null;
        [SerializeField] private PartyManager _partyManager = null;
        [SerializeField] private PortraitRoom _portraitRoom = null;

        private GuiManager _gui = null;
        
        private void Awake()
        {
            _database.Setup();
        }

        private void Start()
        {
            SetupGui();
            _partyManager.Setup();
            _portraitRoom.Setup(_partyManager.PartyData);
            _partyManager.SyncPartyData();
        }

        private void SetupGui()
        {
            GameObject clone = Instantiate(_guiPrefab, null);
            _gui = clone.GetComponent<GuiManager>();
            _gui.Setup();
        }
    }
}
