using System;
using System.Collections;
using System.Collections.Generic;
using Descending.Core;
using Descending.Encounters;
using Descending.Gui;
using Descending.Party;
using Descending.World;
using UnityEngine;

namespace Descending.Scene_Overworld
{
    public class OverworldManager : MonoBehaviour
    {
        [SerializeField] private Database _database = null;
        [SerializeField] private GameObject _guiPrefab = null;
        [SerializeField] private PartyManager _partyManager = null;
        [SerializeField] private PortraitRoom _portraitRoom = null;
        [SerializeField] private WorldGenerator _worldGenerator = null;
        [SerializeField] private EncounterManager _encounterManager = null;

        private GuiManager _gui = null;
        
        private void Awake()
        {
            _database.Setup();
            EncounterGenerator.Setup();
            _worldGenerator.Generate(_partyManager);
            _encounterManager.Setup();
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
