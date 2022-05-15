using System;
using System.Collections;
using System.Collections.Generic;
using Descending.Encounters;
using Descending.Party;
using ScriptableObjectArchitecture;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Descending.Combat
{
    public class CombatManager : MonoBehaviour
    {
        [SerializeField] private CombatGrid _grid = null;
        
        [SerializeField] private BoolEvent onEndCombat_Manager = null;
        
        private CombatParameters _parameters = null;
        private bool _combatStarted = false;

        public void Setup()
        {
        }

        public void StartCombat(CombatParameters combatParameters)
        {
            Debug.Log("Starting Combat");
            _combatStarted = true;
            _parameters = combatParameters;
            _parameters.Party.CombatStarted(combatParameters);

            _grid.Setup(_parameters);
            _grid.transform.position = _parameters.Encounter.transform.position;
            
            LoadHeroes();
            LoadEnemies();
        }

        private void EndCombat()
        {
            Destroy(_parameters.Encounter.gameObject);
            _parameters.Encounter = null;
            
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
                _parameters.Party.PartyData.Heroes[i].SnapToTile();
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
                _parameters.Encounter.Enemies[i].SnapToTile();
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
    }
}