using System;
using System.Collections;
using System.Collections.Generic;
using Descending.Core;
using Descending.Enemies;
using Descending.Party;
using Descension.Core;
using DG.Tweening;
using ScriptableObjectArchitecture;
using UnityEngine;

namespace Descending.Encounters
{    
    public class Encounter : MonoBehaviour
    {
        [SerializeField] private EncounterDifficulties _difficulty = EncounterDifficulties.None;
        [SerializeField] private EnemyGroups _group = EnemyGroups.None;
        [SerializeField] private int _threatLevel = 0;

        [SerializeField] private Transform _enemiesParent = null;
        [SerializeField] private List<Transform> _formation = null;
        [SerializeField] private List<EnemyShort> _enemyData = null;
        [SerializeField] private List<Enemy> _enemies = null;
        [SerializeField] private bool _setParent = true;

        [SerializeField] private EncounterEvent onRegisterEncounter = null;
        [SerializeField] private EncounterEvent onTriggerEncounter = null;

        [SerializeField] private PartyManager _partyManager = null;
        private bool _isActive = false;
        
        public EncounterDifficulties Difficulty => _difficulty;
        public EnemyGroups Group => _group;
        public int ThreatLevel => _threatLevel;
        public bool IsActive => _isActive;
        public List<Enemy> Enemies => _enemies;
        public bool SetParent => _setParent;

        private void Awake()
        {
            onRegisterEncounter.Invoke(this);
        }

        public void Setup(PartyManager partyManager, int threatLevel)
        {
            _partyManager = partyManager;
            _threatLevel = threatLevel;
            name = "Encounter: Threat:" + _threatLevel;
        }
        
        public void SpawnEnemies()
        {
            for (int i = 0; i < _enemyData.Count; i++)
            {
                EnemyDefinition definition = Database.instance.Enemies.GetEnemy(_enemyData[i].Key);
                GameObject clone = Instantiate(definition.Prefab, _enemiesParent);
                clone.transform.position = _formation[i].position;
                
                Animator animator = clone.GetComponentInChildren<Animator>();
                Enemy enemy = clone.GetComponent<Enemy>();
                enemy.Setup(definition, animator, _enemyData[i].Level, i);
                enemy.GetComponent<PlaceOnGround>().Place();
                
                _enemies.Add(enemy);
            }
        }

        public void Trigger()
        {
            onTriggerEncounter.Invoke(this);

            for (int i = 0; i < _enemies.Count; i++)
            {
                _enemies[i].transform.DOLookAt(_partyManager.PartyObject.transform.position, 0.2f);
            }
        }

        public void SetupData(EncounterDifficulties difficulty, EnemyGroups group, List<EnemyShort> enemyData)
        {
            _difficulty = difficulty;
            _group = group;
            _enemyData = enemyData;
            
            SpawnEnemies();
            Deactivate();
        }

        public void Activate()
        {
            _isActive = true;

            for (int i = 0; i < _enemies.Count; i++)
            {
                _enemies[i].gameObject.SetActive(true);
            }
        }

        public void Deactivate()
        {
            _isActive = false;

            for (int i = 0; i < _enemies.Count; i++)
            {
                _enemies[i].gameObject.SetActive(false);
            }
        }
    }
}
