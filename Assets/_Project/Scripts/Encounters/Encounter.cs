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

        //[SerializeField] private GameObject _ring = null;
        [SerializeField] private Transform _enemiesParent = null;
        [SerializeField] private List<Transform> _formation = null;
        [SerializeField] private List<EnemyShort> _enemyData = null;
        [SerializeField] private List<Enemy> _enemies = null;
        [SerializeField] private bool _setParent = true;

        [SerializeField] private EncounterEvent onRegisterEncounter = null;   
        
        private bool _isActive = false;
        private Vector3 _combatCamPosition;
        
        public EncounterDifficulties Difficulty => _difficulty;
        public EnemyGroups Group => _group;
        public int ThreatLevel => _threatLevel;
        public bool IsActive => _isActive;
        public Vector3 CombatCamPosition => _combatCamPosition;
        public List<Enemy> Enemies => _enemies;
        public bool SetParent => _setParent;

        private void Awake()
        {
            //Debug.Log("Encounter.Awake");
            onRegisterEncounter.Invoke(this);
            
            SetActive(false);
        }
        
        public void Setup(EncounterDifficulties difficulty, EnemyGroups group, int threatLevel, List<EnemyShort> enemies)
        {
            _difficulty = difficulty;
            _group = group;
            _threatLevel = threatLevel;
            _enemyData = enemies;
            
            if (_threatLevel < 1) _threatLevel = 1;
        }

        public void SetCombatActive(bool active)
        {
            //_ring.SetActive(active);
            _triggerCollider.enabled = active;
        }

        public void SpawnEnemies()
        {
            ClearFLora();
            
            for (int i = 0; i < _enemyData.Count; i++)
            {
                EnemyDefinition definition = Database.instance.Enemies.GetEnemy(_enemyData[i].Key);
                GameObject clone = Instantiate(definition.Prefab, _enemiesParent);
                clone.transform.position = _formation[i].position;
                
                Animator animator = clone.GetComponentInChildren<Animator>();
                Enemy enemy = clone.GetComponent<Enemy>();
                enemy.Setup(definition, animator, _enemyData[i].Level);
                enemy.gameObject.SetActive(false);
                enemy.GetComponent<PlaceOnGround>().Place();
                
                _enemies.Add(enemy);
            }
        }

        private void ClearFLora()
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, 8f);
            foreach (var hitCollider in hitColliders)
            {
                if (hitCollider.CompareTag("Flora"))
                {
                    Destroy(hitCollider.gameObject);
                }
            }
        }

        public void SetParentOnSpawn(bool setParent)
        {
            _setParent = setParent;
        }
        
        public void SetActive(bool active)
        {
            _isActive = active;

            SetEnemiesActive(_isActive);
            //_ring.SetActive(_isActive);
        }

        private void SetEnemiesActive(bool active)
        {
            for (int i = 0; i < _enemies.Count; i++)
            {
                _enemies[i].gameObject.SetActive(active);
            }
        }

        public void SetCombatCamPosition(Vector3 position)
        {
            _combatCamPosition = position;
        }
    }
}
