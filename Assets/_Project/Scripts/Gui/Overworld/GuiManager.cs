using System;
using System.Collections;
using System.Collections.Generic;
using Descending.Combat;
using Descending.Core;
using Descending.Encounters;
using Descending.Gui;
using Descending.Party;
using Descending.World;
using UnityEngine;

namespace Descending.Scene_Overworld.Gui
{
    public enum GuiModes { World, Combat }
    
    public class  GuiManager : MonoBehaviour
    {
        [SerializeField] private WindowManager _windowManager = null;
        [SerializeField] private InputManager _inputManager = null;
        
        [SerializeField] private GameObject _tooltipPrefab = null;
        [SerializeField] private GameObject _partyPrefab = null;
        [SerializeField] private GameObject _resourcesPrefab = null;
        [SerializeField] private GameObject _timePrefab = null;
        [SerializeField] private GameObject _combatPrefab = null;

        private GuiModes _mode = GuiModes.World;
        private Tooltip _tooltip = null;
        private PartyPanel _partyPanel = null;
        private ResourcesPanel _resourcesPanel = null;
        private TimePanel _timePanel = null;
        private CombatPanel _combatPanel = null;
        
        public void Setup(PartyController party)
        {
            SpawnPartyPanel();
            SpawnResourcesPanel();
            SpawnTimePanel();
            SpawnCombatPanel();
            SetMode(GuiModes.World);
            
            _windowManager.Setup(party);
            _windowManager.transform.SetAsLastSibling();
            _inputManager.SetWindowManager(_windowManager);
            
            SpawnTooltip();
        }

        public void SetMode(GuiModes mode)
        {
            _mode = mode;
            if (_mode == GuiModes.World)
            {
                WorldMode();
            }
            else if (_mode == GuiModes.Combat)
            {
                CombatMode();
            }
        }

        private void WorldMode()
        {
            _partyPanel.Show();
            _resourcesPanel.Show();
            _timePanel.Show();
            
            _combatPanel.Hide();
        }

        private void CombatMode()
        {
            _combatPanel.Show();
            
            _resourcesPanel.Hide();
            _timePanel.Hide();
            _partyPanel.Hide();
        }

        private void SpawnPartyPanel()
        {
            GameObject clone = Instantiate(_partyPrefab, transform);
            _partyPanel = clone.GetComponentInChildren<PartyPanel>();
            _partyPanel.Setup();
        }

        private void SpawnResourcesPanel()
        {
            GameObject clone = Instantiate(_resourcesPrefab, transform);
            _resourcesPanel = clone.GetComponentInChildren<ResourcesPanel>();
            _resourcesPanel.Setup();
        }

        private void SpawnTimePanel()
        {
            GameObject clone = Instantiate(_timePrefab, transform);
            _timePanel = clone.GetComponentInChildren<TimePanel>();
            _timePanel.Setup();
        }

        private void SpawnTooltip()
        {
            GameObject clone = Instantiate(_tooltipPrefab, null);
            _tooltip = clone.GetComponentInChildren<Tooltip>();
            _tooltip.Setup();
            _tooltip.transform.SetAsLastSibling();
        }

        private void SpawnCombatPanel()
        {
            GameObject clone = Instantiate(_combatPrefab, transform);
            _combatPanel = clone.GetComponentInChildren<CombatPanel>();
        }

        public void OnCombatStarted(CombatParameters parameters)
        {
            if (parameters == null) return;
            
            //_combatPanel.Setup(parameters);
            SetMode(GuiModes.Combat);
        }

        public void OnCombatEnded_Manager(bool b)
        {
            SetMode(GuiModes.World);
        }

        public void OnCombatEnded_Gui(bool b)
        {
            SetMode(GuiModes.World);
        }
    }
}
