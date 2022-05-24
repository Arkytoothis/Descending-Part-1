using System.Collections;
using System.Collections.Generic;
using Descending.Characters;
using Descending.Core;
using Descending.Party;
using ScriptableObjectArchitecture;
using UnityEngine;

namespace Descending.Gui.Party_Window
{
    public class PartyWindow : GameWindow
    {
        [SerializeField] private GameObject _partyWidgetPrefab = null;
        [SerializeField] private Transform _partyWidgetsParent = null;
        [SerializeField] private DetailsPanel _detailsPanel = null;
        [SerializeField] private AttributesPanel _attributesPanel = null;
        [SerializeField] private SkillsPanel _skillsPanel = null;
        [SerializeField] private PortraitPanel _portraitPanel = null;
        [SerializeField] private EquipmentPanel _equipmentPanel = null;
        [SerializeField] private AbilitiesPanel _abilitiesPanel = null;

        [SerializeField] private ItemEvent onHideTooltip = null;
        
        private List<PartyWidget> _partyWidgets = null;
        private PartyController _party = null;
        
        public override void Setup()
        {
            Close();
        }

        public override void Open()
        {
            SelectHero(_party.PartyData.Heroes[0]);
            Time.timeScale = 0;
            _isOpen = true;
            _container.SetActive(true);
        }

        public override void Close()
        {
            Time.timeScale = 1;
            _isOpen = false;
            _container.SetActive(false);
            onHideTooltip.Invoke(null);
        }

        public void CloseButtonClick()
        {
            Close();
        }

        public void OnSyncParty(PartyController party)
        {
            _party = party;
            if (_party == null) return;

            _partyWidgets = new List<PartyWidget>();
            _partyWidgetsParent.ClearTransform();

            for (int i = 0; i < _party.PartyData.Heroes.Count; i++)
            {
                GameObject clone = Instantiate(_partyWidgetPrefab, _partyWidgetsParent);
                PartyWidget widget = clone.GetComponent<PartyWidget>();
                widget.DisplayHero(this, _party.PartyData.Heroes[i]);
                _partyWidgets.Add(widget);
            }
        }

        public void SelectHero(Hero hero)
        {
            _detailsPanel.SelectHero(hero);
            _attributesPanel.SelectHero(hero);
            _skillsPanel.SelectHero(hero);
            _portraitPanel.SelectHero(hero);
            _equipmentPanel.SelectHero(hero);
            _abilitiesPanel.SelectHero(hero);
        }
    }
}
