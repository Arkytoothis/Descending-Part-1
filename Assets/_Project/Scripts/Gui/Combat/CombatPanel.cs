using System;
using System.Collections;
using System.Collections.Generic;
using Descending.Combat;
using Descending.Encounters;
using Descending.Party;
using ScriptableObjectArchitecture;
using TMPro;
using UnityEngine;

namespace Descending.Gui
{
    public class CombatPanel : MonoBehaviour
    {
        [SerializeField] private GameObject _container = null;
        [SerializeField] private InitiativePanel _initiativePanel = null;
        [SerializeField] private CurrentEntityPanel _entityPanel = null;
        
        private GuiManager _guiManager = null;
        private PartyManager _partyManager = null;
        private Encounter _currentEncounter = null;
        private InitiativeDataList _initiativeList = null;
        
        public void Setup(GuiManager guiManager)
        {
            _guiManager = guiManager;
            _initiativePanel.Setup();
        }
        
        public void Show()
        {
            _container.SetActive(true);
        }

        public void Hide()
        {
            _container.SetActive(false);
        }
        
        public void EndCombatButtonClick()
        {
            _guiManager.EndCombat();
        }

        public void StartCombat(PartyManager partyManager, Encounter encounter)
        {
            _partyManager = partyManager;
            _currentEncounter = encounter;
            _initiativePanel.StartCombat(_partyManager, _currentEncounter);
        }

        public void OnSyncInitiativeList(InitiativeDataList list)
        {
            _initiativeList = list;
            _initiativePanel.SyncInitiativeList(list);
        }

        public void OnProcessInitiative(int initiativeIndex)
        {   
            Debug.Log("Processing Initiative " + initiativeIndex);
            _initiativePanel.ProcessInitiative(initiativeIndex);

            if (_initiativeList.List[initiativeIndex].Hero != null)
            {
                _entityPanel.SetHero(_initiativeList.List[initiativeIndex].Hero);
            }
            else if (_initiativeList.List[initiativeIndex].Enemy != null)
            {
                _entityPanel.SetEnemy(_initiativeList.List[initiativeIndex].Enemy);
            }
        }
    }
}