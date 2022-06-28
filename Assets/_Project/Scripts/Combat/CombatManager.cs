using System;
using System.Collections;
using System.Collections.Generic;
using Descending.Abilities;
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
        [SerializeField] private WorldRaycaster _raycaster = null;
        
        [SerializeField] private InitiativeDataListEvent onSyncInitiativeList = null;
        [SerializeField] private BoolEvent onSyncCombatData = null;
        [SerializeField] private IntEvent onProcessInitiative = null;
        [SerializeField] private BoolEvent onSetEnemyClickEnabled = null;
        
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
            //Debug.Log("Starting Combat");
            _raycaster.SetRaycastMode(RaycastModes.Combat);
            _partyManager = parameters.PartyManager;
            _encounter = parameters.Encounter;
            _currentInitiative = -1;
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
            
            _initiativeList.Sort((a, b) => a.InitiativeRoll.CompareTo(b.InitiativeRoll));

            for (int i = 0; i < _initiativeList.Count; i++)
            {
                if (_initiativeList[i].Hero != null)
                {
                    _initiativeList[i].Hero.SetInitiativeIndex(i); 
                }
                else if (_initiativeList[i].Enemy != null)
                {
                    _initiativeList[i].Enemy.SetInitiativeIndex(i); 
                }
            }
                
            
            onSyncInitiativeList.Invoke(new InitiativeDataList(_initiativeList));
        }

        private void ProcessTurn()
        {
            NextInitiative();
            
            if (_initiativeList[_currentInitiative].Hero != null)
            {
                ProcessHeroTurn();
            }
            else if (_initiativeList[_currentInitiative].Enemy != null)
            {
                ProcessEnemyTurn();
            }
            
            RefreshActions();
        }

        private void NextInitiative()
        {
            _currentInitiative++;
            if (_currentInitiative >= _initiativeList.Count)
            {
                _currentInitiative = 0;
            }
        }

        private void RefreshActions()
        {
            for (int i = 0; i < _initiativeList.Count; i++)
            {
                if (_initiativeList[i].Hero != null)
                {
                    _initiativeList[i].Hero.Attributes.RefreshActions();
                }
                else if (_initiativeList[i].Enemy != null)
                {
                    _initiativeList[i].Enemy.Attributes.RefreshActions();
                }
            }
        }
        
        private void ProcessHeroTurn()
        {
            onSetEnemyClickEnabled.Invoke(true);
            Hero hero = _initiativeList[_currentInitiative].Hero;
            //Debug.Log("Processing Hero: " + hero.HeroData.Name.ShortName);
            onProcessInitiative.Invoke(_currentInitiative);
        }

        private void ProcessEnemyTurn()
        {
            onSetEnemyClickEnabled.Invoke(false);
            Enemy enemy = _initiativeList[_currentInitiative].Enemy;
            //Debug.Log("Processing Enemy: " + enemy.EnemyDefinition.Name);
            onProcessInitiative.Invoke(_currentInitiative);

            StartCoroutine(ProcessTurn_Coroutine());
        }

        private IEnumerator ProcessTurn_Coroutine()
        {
            yield return new WaitForSeconds(1f);
            
            ProcessTurn();
        }

        public void OnEnemyClicked_Left(Enemy enemy)
        {
            Hero hero = GetCurrentHero();
            //Debug.Log(hero.HeroData.Name.ShortName + " attacked " + enemy.EnemyDefinition.Name);
            AttackData attackData = AttackCalculator.ProcessAttack(hero, enemy);
            
            onSyncCombatData.Invoke(true);
        }

        public void OnEnemyClicked_Right(Enemy enemy)
        {
            Hero hero = GetCurrentHero();
            Debug.Log(hero.HeroData.Name.ShortName + " right clicked " + enemy.EnemyDefinition.Name);
        }

        private Hero GetCurrentHero()
        {
            return _initiativeList[_currentInitiative].Hero;
        }

        private Enemy GetCurrentEnemy()
        {
            return _initiativeList[_currentInitiative].Enemy;
        }

        public void OnAbilitySelected(Ability ability)
        {
            if (ability == null)
            {
                Debug.Log("ability == null");
            }
            else
            {
                Debug.Log(ability.Definition.Details.Name + " selected");
                _raycaster.SetAbility(ability);
                _raycaster.SetRaycastMode(RaycastModes.Ability);
            }
        }
    }
}