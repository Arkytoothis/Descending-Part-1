using System;
using System.Collections;
using System.Collections.Generic;
using Descending.Characters;
using Descending.Encounters;
using Descending.Enemies;
using Descending.Party;
using ScriptableObjectArchitecture;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Descending.Combat
{
    public class CombatManager : MonoBehaviour
    {
        [SerializeField] private InitiativeDataListEvent onSyncInitiativeList = null;
        [SerializeField] private IntEvent onProcessInitiative = null;
        
        private PartyManager _partyManager = null;
        private Encounter _encounter = null;
        private List<InitiativeData> _initiativeList = null;
        private int _currentInitiative = -1;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                ProcessTurn();
            }
        }

        public void OnStartCombat(CombatParameters parameters)
        {
            Debug.Log("Starting Combat");
            _partyManager = parameters.PartyManager;
            _encounter = parameters.Encounter;
            _currentInitiative = 0;
            RollInitiative();
            ProcessTurn();
        }

        private void RollInitiative()
        {
            _initiativeList = new List<InitiativeData>();

            for (int i = 0; i < _partyManager.PartyData.Heroes.Count; i++)
            {
                int initiative = Random.Range(1, 100) + _partyManager.PartyData.Heroes[i].Attributes.GetStatistic("Speed").Current;
                InitiativeData data = new InitiativeData(initiative, _partyManager.PartyData.Heroes[i]);
                _initiativeList.Add(data);
            }
            
            for (int i = 0; i < _encounter.Enemies.Count; i++)
            {
                int initiative = Random.Range(1, 100) + _encounter.Enemies[i].Attributes.GetStatistic("Speed").Current;
                InitiativeData data = new InitiativeData(initiative, _encounter.Enemies[i]);
                _initiativeList.Add(data);
            }
            
            onSyncInitiativeList.Invoke(new InitiativeDataList(_initiativeList));
        }

        private void ProcessTurn()
        {
            if (_initiativeList[_currentInitiative].Hero != null)
            {
                ProcessHeroTurn();
            }
            else if (_initiativeList[_currentInitiative].Enemy != null)
            {
                ProcessEnemyTurn();
            }
            
            _currentInitiative++;
            if (_currentInitiative >= _initiativeList.Count)
            {
                _currentInitiative = 0;
            }
        }

        private void ProcessHeroTurn()
        {
            Hero hero = _initiativeList[_currentInitiative].Hero;
            Debug.Log("Processing Hero: " + hero.HeroData.Name.ShortName);
            onProcessInitiative.Invoke(_currentInitiative);
        }

        private void ProcessEnemyTurn()
        {
            Enemy enemy = _initiativeList[_currentInitiative].Enemy;
            Debug.Log("Processing Enemy: " + enemy.EnemyDefinition.Name);
            onProcessInitiative.Invoke(_currentInitiative);

            StartCoroutine(ProcessTurn_Coroutine());
        }

        private IEnumerator ProcessTurn_Coroutine()
        {
            yield return new WaitForSeconds(1f);
            
            ProcessTurn();
        }
    }
}