using System.Collections;
using System.Collections.Generic;
using Descending.Combat;
using Descending.Core;
using Descending.Encounters;
using Descending.Party;
using ScriptableObjectArchitecture;
using TMPro;
using UnityEngine;

namespace Descending.Gui
{
    public class EncounterWindow : GameWindow
    {
        [SerializeField] private GameObject _heroWidgetPrefab = null;
        [SerializeField] private Transform _heroWidgetsParent = null;
        [SerializeField] private GameObject _enemyWidgetPrefab = null;
        [SerializeField] private Transform _enemyWidgetsParent = null;
        
        [SerializeField] private TMP_Text _nameLabel = null;
        [SerializeField] private TMP_Text _encounterDetailsLabel = null;

        //[SerializeField] private CombatParametersEvent onStartCombat = null;
        
        private PartyData _partyData = null;
        private Encounter _encounter = null;
        private List<HeroEncounterWidget> _heroWidgets = null;
        private List<EnemyEncounterWidget> _enemyWidgets = null;
        
        public override void Setup()
        {
            _heroWidgets = new List<HeroEncounterWidget>();
            _enemyWidgets = new List<EnemyEncounterWidget>();
            Close();
        }

        public override void Open()
        {
            Time.timeScale = 0;
            _isOpen = true;
            _container.SetActive(true);
        }

        public override void Close()
        {
            Time.timeScale = 1;
            _isOpen = false;
            _container.SetActive(false);
        }

        public void CloseButtonClick()
        {
            Close();
        }

        public void LoadEncounter(Encounter encounter)
        {
            _encounter = encounter;
            if (encounter == null || _partyData == null) return;
            
            _nameLabel.text = encounter.name;
            _encounterDetailsLabel.text = encounter.Difficulty + " " + encounter.Group + " encounter";
            _heroWidgetsParent.ClearTransform();
            _heroWidgets.Clear();
            _enemyWidgetsParent.ClearTransform();
            _enemyWidgets.Clear();
            
            for (int i = 0; i < _partyData.Heroes.Count; i++)
            {
                GameObject clone = Instantiate(_heroWidgetPrefab, _heroWidgetsParent);
                HeroEncounterWidget widget = clone.GetComponent<HeroEncounterWidget>();
                widget.Setup(_partyData.Heroes[i]);
                _heroWidgets.Add(widget);
            }
            
            for (int i = 0; i < _encounter.Enemies.Count; i++)
            {
                GameObject clone = Instantiate(_enemyWidgetPrefab, _enemyWidgetsParent);
                EnemyEncounterWidget widget = clone.GetComponent<EnemyEncounterWidget>();
                widget.Setup(_encounter.Enemies[i]);
                _enemyWidgets.Add(widget);
            }
            
            Open();
        }

        public void StartCombatButtonClick()
        {
            //onStartCombat.Invoke(new CombatParameters(_party, _encounter));
            _encounter = null;
            Close();
        }

        public void AutoCombatButtonClick()
        {
            Destroy(_encounter.gameObject);
            _encounter = null;
            Close();
        }

        public void BribeButtonClick()
        {
            Destroy(_encounter.gameObject);
            _encounter = null;
            Close();
        }

        public void RetreatButtonClick()
        {
            _encounter = null;
            Close();
        }

        public void OnSyncParty(PartyData partyData)
        {
            _partyData = partyData;
        }
    }
}
