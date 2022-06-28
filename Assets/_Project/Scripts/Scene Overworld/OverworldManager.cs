using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Descending.Core;
using Descending.Encounters;
using Descending.Equipment;
using Descending.Gui;
using Descending.Party;
using Descending.World;
using Sirenix.Serialization;
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
        private SceneLoadData _sceneLoadData = null;
        private PartySpawnData _partySpawnData = null;
        
        private void Awake()
        {
            LoadSceneData();
            LoadPartySpawnData();

            if (_sceneLoadData.TransitionType == SceneTransitionTypes.Main_Menu_Play)
            {
                
            }
            else if (_sceneLoadData.TransitionType == SceneTransitionTypes.Underworld_Overworld)
            {
                _partyManager.SetSpawnerPosition(_partySpawnData.SpawnPosition);
            }
            
            _database.Setup();
            ItemGenerator.Setup();
            EncounterGenerator.Setup();
            _worldGenerator.Generate(_partyManager, _sceneLoadData);
            _encounterManager.Setup();
        }

        private void LoadPartySpawnData()
        {
            if (File.Exists(Database.instance.PartySpawnFilePath))
            {
                byte[] bytes = File.ReadAllBytes(Database.instance.PartySpawnFilePath);
                _partySpawnData = SerializationUtility.DeserializeValue<PartySpawnData>(bytes, DataFormat.JSON);
            }
        }

        private void LoadSceneData()
        {
            if (File.Exists(Database.instance.SceneLoadFilePath))
            {
                byte[] bytes = File.ReadAllBytes(Database.instance.SceneLoadFilePath);
                _sceneLoadData = SerializationUtility.DeserializeValue<SceneLoadData>(bytes, DataFormat.JSON);
            }
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

        private void SaveState()
        {
            
        }
    }
}
