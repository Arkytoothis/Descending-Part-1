using System;
using System.Collections;
using System.Collections.Generic;
using Descending.Combat;
using Descending.Core;
using Descending.Party;
using Descending.Scene_Overworld.Gui;
using UnityEngine;

namespace Descending.Scene_Underground
{
    public class UndergroundManager : MonoBehaviour
    {
        [SerializeField] private Database _database = null;
        [SerializeField] private CombatManager _combatManager = null;
        [SerializeField] private PortraitRoom _portraitRoom = null;
        [SerializeField] private PartyController _partyController = null;
        [SerializeField] private GameObject _guiPrefab = null;
        [SerializeField] private Transform _guiParent = null;
        [SerializeField] private bool _loadData = true;

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
            _combatManager.Setup();
        }

        private void SpawnGui()
        {
            GameObject clone = Instantiate(_guiPrefab, _guiParent);
            _gui = clone.GetComponent<GuiManager>();
            _gui.Setup(_partyController);
        }

        public void SpawnParty(Vector3 spawnPosition)
        {
            _partyController.transform.position = spawnPosition;
        }
    }
}