using System;
using System.Collections;
using System.Collections.Generic;
using Descending.Core;
using Descending.Party;
using Descending.Scene_Overworld.Gui;
using Descending.World;
using UnityEngine;

namespace Descending.Scene_Overworld
{
    public class OverworldManager : MonoBehaviour
    {
        [SerializeField] private bool _loadData = true;

        [SerializeField] private Database _database = null;

        // [SerializeField] private VolumetricFog _fogofWar = null;
        // [SerializeField] private CombatManager _combatManager = null;
        [SerializeField] private PortraitRoom _portraitRoom = null;

        // [SerializeField] private EncounterManager _encounterManager = null;
        // [SerializeField] private TreasureManager _treasureManager = null;
        [SerializeField] private bool _enableFoW = true;
        [SerializeField] private PartyController _partyController = null;
        [SerializeField] private GameObject _guiPrefab = null;
        [SerializeField] private Transform _guiParent = null;

        private GuiManager _gui = null;

        private void Awake()
        {
            _database.Setup();
        }

        void Start()
        {
            SpawnGui();

            if (_loadData == false)
            {
                _partyController.Setup();
            }
            else
            {
                _partyController.Load();
            }

            _portraitRoom.Setup(_partyController.PartyData);
            _partyController.Select();
            //_worldGenerator.Generate();
            //_encounterManager.Setup();
            //_encounterManager.GenerateEncounters(_worldGenerator.StartPosition, _worldGenerator.ThreatModifier);
            //_treasureManager.Setup(_worldGenerator.StartPosition, _worldGenerator.ThreatModifier);
            //_combatManager.Setup();

            if (_enableFoW == true)
            {
                //_fogofWar.gameObject.SetActive(true);
            }
            else
            {
                //_fogofWar.gameObject.SetActive(false);
            }
        }

        private void SpawnGui()
        {
            GameObject clone = Instantiate(_guiPrefab, _guiParent);
            _gui = clone.GetComponent<GuiManager>();
            _gui.Setup(_partyController);
        }

        public void EnterDungeon(Dungeon dungeon)
        {
            Debug.Log("Starting Dungeon");
        }
    }
}