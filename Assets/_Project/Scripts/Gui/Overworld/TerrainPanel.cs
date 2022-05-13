using System.Collections;
using System.Collections.Generic;
using Descending.Party;
using Descending.World;
using ScriptableObjectArchitecture;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Descending.Scene_Overworld.Gui
{
    public class TerrainPanel : MonoBehaviour
    {
        //[SerializeField] private TMP_Text _terrainDetailsLabel = null;
        [SerializeField] private TMP_Text _featureLabel = null;
        [SerializeField] private TMP_Text _treasureLabel = null;

        [SerializeField] private Button _featureButton = null;
        [SerializeField] private Button _treasureButton = null;

        [SerializeField] private VillageEvent onInteractWithVillage = null;
        [SerializeField] private DungeonEvent onInteractWithDungeon = null;
        [SerializeField] private TreasureEvent onInteractWithTreasure = null;
        [SerializeField] private GameObject _container = null;
        
        private Feature _currentFeature = null;
        private Treasure _currentTreasure = null;
        
        public void Setup()
        {
            _featureButton.interactable = false;
            _treasureButton.interactable = false;
        }

        public void Show()
        {
            _container.SetActive(true);
        }

        public void Hide()
        {
            _container.SetActive(false);
        }

        public void FeatureButtonClick()
        {
            //Debug.Log("Interacting with Feature: " + _currentFeature.Definition.Name);
             if (_currentFeature.GetType() == typeof(Village))
             {
                 onInteractWithVillage.Invoke((Village)_currentFeature);
             }
             else if (_currentFeature.GetType() == typeof(Dungeon))
             {
                 onInteractWithDungeon.Invoke((Dungeon)_currentFeature);
             }
        }

        public void TreasureButtonCLick()
        {
            //Debug.Log("Interacting with Treasure: " + _currentTreasure.name);
            onInteractWithTreasure.Invoke(_currentTreasure);
        }

        public void OnFeatureEntered(Feature feature)
        {
            _currentFeature = feature;
            _featureLabel.SetText("Feature: " + _currentFeature.Definition.Name);
            _featureButton.interactable = true;
        }

        public void OnFeatureExited(Feature feature)
        {
            _currentFeature = null;
            _featureLabel.SetText("");
            _featureButton.interactable = false;
        }

        public void OnTreasureEncountered(Treasure treasure)
        {
            //Debug.Log("Treasure Encountered");
            _currentTreasure = treasure;
            _treasureLabel.SetText("Treasure: " + _currentTreasure.name);
            _treasureButton.interactable = true;
        }

        public void OnTreasureLooted(Treasure treasure)
        {
            _currentTreasure = null;
            _treasureLabel.SetText("");
            _treasureButton.interactable = false;
        }
    }
}
