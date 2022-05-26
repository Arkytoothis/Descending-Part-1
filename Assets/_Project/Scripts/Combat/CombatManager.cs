using System;
using System.Collections;
using System.Collections.Generic;
using ScriptableObjectArchitecture;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Descending.Combat
{
    public class CombatManager : MonoBehaviour
    {
        [SerializeField] private CombatGrid _grid = null;

        [SerializeField] private CombatParametersEvent onSyncCombatParameters = null;
        [SerializeField] private BoolEvent onEndCombat_Manager = null;
        
        private CombatParameters _parameters = null;
        private bool _combatStarted = false;
        
        public void Setup()
        {
        }

        public void StartCombat(CombatParameters combatParameters)
        {
            //Debug.Log("Starting Combat");
            _combatStarted = true;
            _parameters = combatParameters;
            _parameters.Party.CombatStarted(combatParameters);

            _grid.StartCombat(_parameters);
            
            LoadHeroes();
            LoadEnemies();
            
            RollInitiative();
            
            onSyncCombatParameters.Invoke(_parameters);
        }

        private void EndCombat()
        {
            //Debug.Log("Ending Combat");
            _parameters.Party.OnCombatEnded(true);
            Destroy(_parameters.Encounter.gameObject);
            _parameters.Encounter = null;
            _parameters.InitiativeList.Clear();
            _grid.EndCombat();
            
            for (int i = 0; i < _parameters.Party.PartyData.Heroes.Count; i++)
            {
                _parameters.Party.PartyData.Heroes[i].LifeBar.Hide();
            }
        }
        
        public void OnEndCombat_Gui(bool b)
        {
            EndCombat();
        }

        private void LoadHeroes()
        {
            for (int i = 0; i < _parameters.Party.PartyData.Heroes.Count; i++)
            {
                _parameters.Party.PartyData.Heroes[i].LifeBar.Show();
            }

            StartCoroutine(SnapHeroes());
        }

        private IEnumerator SnapHeroes()
        {
            yield return new WaitForSeconds(0.1f);
            
            for (int i = 0; i < _parameters.Party.PartyData.Heroes.Count; i++)
            {
                CombatTile tile = _parameters.Party.PartyData.Heroes[i].SnapToTile();
                tile.SetGameEntity(_parameters.Party.PartyData.Heroes[i]);
            }
        }

        private void LoadEnemies()
        {
            for (int i = 0; i < _parameters.Encounter.Enemies.Count; i++)
             {
                 _parameters.Encounter.Enemies[i].SetInfoBarActive(true);
             }

            StartCoroutine(SnapEnemies());
        }

        private IEnumerator SnapEnemies()
        {
            yield return new WaitForSeconds(0.1f);
            for (int i = 0; i < _parameters.Encounter.Enemies.Count; i++)
            {
                CombatTile tile = _parameters.Encounter.Enemies[i].SnapToTile();
                tile.SetGameEntity(_parameters.Encounter.Enemies[i]);
                _parameters.Encounter.Enemies[i].transform.LookAt(_parameters.Party.PartyData.Heroes[0].transform, Vector3.up);
            }
        }

        private bool CheckForEndOfCombat()
        {
            bool allEnemiesKilled = true;

            for (int i = 0; i < _parameters.Encounter.Enemies.Count; i++)
            {
                if (_parameters.Encounter.Enemies[i].IsAlive() == true)
                {
                    allEnemiesKilled = false;
                }
            }
            
            return allEnemiesKilled;
        }

        private void RollInitiative()
        {
            //Debug.Log("Rolling Initiative");
            var initiativeList = new List<InitiativeData>();

            for (int i = 0; i < _parameters.Party.PartyData.Heroes.Count; i++)
            {
                int initiativeRoll = Random.Range(1, 101);
                InitiativeData data = new InitiativeData(initiativeRoll, _parameters.Party.PartyData.Heroes[i]);
                initiativeList.Add(data);
            }

            for (int i = 0; i < _parameters.Encounter.Enemies.Count; i++)
            {
                int initiativeRoll = Random.Range(1, 101);
                InitiativeData data = new InitiativeData(initiativeRoll, _parameters.Encounter.Enemies[i]);
                initiativeList.Add(data);
            }
            
            initiativeList.Sort((p1,p2)=>p1.InitiativeRoll.CompareTo(p2.InitiativeRoll));
            _parameters.SetInitiativeList(initiativeList);
        }
    }
}