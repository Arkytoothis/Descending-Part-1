using System;
using System.Collections;
using System.Collections.Generic;
using Descending.Core;
using Descending.Enemies;
using Descension.Core;
using ScriptableObjectArchitecture;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Descending.Encounters
{
    public enum EncounterDifficulties
    {
        Easy, Standard, Hard, 
        Number, None
    }
    
    public class Encounter : MonoBehaviour
    {
        [SerializeField] private EncounterDifficulties _difficulty = EncounterDifficulties.None;
        [SerializeField] private EnemyGroups _group = EnemyGroups.None;
        [SerializeField] private Collider _triggerCollider = null;
        [SerializeField] private int _threatLevel = 0;

        [SerializeField] private Transform _enemiesParent = null;
        [SerializeField] private List<Transform> _formation = null;
        [SerializeField] private List<EnemyShort> _enemyData = null;
        [SerializeField] private List<Enemy> _enemies = null;
        [SerializeField] private bool _setParent = true;

        [SerializeField] private EncounterEvent onTriggerEncounter = null;
        
        private bool _isActive = false;
        
        public EncounterDifficulties Difficulty => _difficulty;
        public EnemyGroups Group => _group;
        public int ThreatLevel => _threatLevel;
        public bool IsActive => _isActive;
        public List<Enemy> Enemies => _enemies;
        public bool SetParent => _setParent;

        private void Start()
        {
            SpawnEnemies();
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
                enemy.Setup(definition, animator, _enemyData[i].Level);
                enemy.GetComponent<PlaceOnGround>().Place();
                
                _enemies.Add(enemy);
            }
        }

        public void Trigger()
        {
            onTriggerEncounter.Invoke(this);
        }
    }
}
