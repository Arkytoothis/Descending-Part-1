using System.Collections;
using System.Collections.Generic;
using Descending.Gui;
using Descending.Scene_Overworld.Gui;
using UnityEngine;

namespace Descending.Scene_Overworld_FP.Gui
{
    public class GuiManager : MonoBehaviour
    {
        [SerializeField] private WindowManager _windowManager = null;
        [SerializeField] private GameObject _partyPanelPrefab = null;
        [SerializeField] private GameObject _resourcesPanelPrefab = null;
        [SerializeField] private GameObject _timePanelPrefab = null;
        [SerializeField] private GameObject _tooltipPrefab = null;

        private PartyPanel _partyPanel = null;
        private ResourcesPanel _resourcesPanel = null;
        private TimePanel _timePanel = null;
        private Tooltip _tooltip = null;
        
        public void Setup()
        {
            SetupPartyPanel();
            SetupResourcesPanel();
            SetupTimePanel();
            SetupTooltip();
            
            _windowManager.Setup();
            _windowManager.transform.SetAsLastSibling();
        }

        private void SetupPartyPanel()
        {
            GameObject clone = Instantiate(_partyPanelPrefab, transform);
            _partyPanel = clone.GetComponent<PartyPanel>();
            _partyPanel.Setup();
        }

        private void SetupResourcesPanel()
        {
            GameObject clone = Instantiate(_resourcesPanelPrefab, transform);
            _resourcesPanel = clone.GetComponent<ResourcesPanel>();
            _resourcesPanel.Setup();
        }

        private void SetupTimePanel()
        {
            GameObject clone = Instantiate(_timePanelPrefab, transform);
            _timePanel = clone.GetComponent<TimePanel>();
            _timePanel.Setup();
        }

        private void SetupTooltip()
        {
            GameObject clone = Instantiate(_tooltipPrefab, null);
            _tooltip = clone.GetComponentInChildren<Tooltip>();
            _tooltip.Setup();
        }
    }
}