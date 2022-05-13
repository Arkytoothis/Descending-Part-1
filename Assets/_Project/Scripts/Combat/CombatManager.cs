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
        [SerializeField] private BoolEvent onEndCombat_Manager = null;
        
        private PartyController _party = null;
        private Encounter _encounter = null;
        private bool _combatStarted = false;
        
        private void Update()
        {
            if (_encounter == null || _combatStarted == false) return;
            
            if (CheckForEndOfCombat() == true)
            {
                onEndCombat_Manager.Invoke(true);
                EndCombat();
            }
        }

        public void StartCombat(CombatParameters combatParameters)
        {
            _combatStarted = true;
            _party = combatParameters.Party;
            _party.CombatStarted(combatParameters);
            _party.Formation.SetFlagActive(false);
            _encounter = combatParameters.Encounter;
            _encounter.SetCombatActive(false);
            
            LoadHeroes();
            LoadEnemies();
        }

        private void EndCombat()
        {
            _encounter.SetCombatActive(true);
            Destroy(_encounter.gameObject);
            _encounter = null;
            
            for (int i = 0; i < _party.PartyData.Heroes.Count; i++)
            {
                //_party.PartyData.Heroes[i].BehaviorController.SetBehaviorActive(false);
                _party.PartyData.Heroes[i].LifeBar.Hide();
            }
            
            _party.MoveToFormation();
        }
        
        public void OnEndCombat_Gui(bool b)
        {
            EndCombat();
        }

        public void Setup()
        {
        }

        private void LoadHeroes()
        {
            for (int i = 0; i < _party.PartyData.Heroes.Count; i++)
            {
                //_party.PartyData.Heroes[i].BehaviorController.SetBehaviorActive(true);
                _party.PartyData.Heroes[i].LifeBar.Show();
            }
        }

        private void LoadEnemies()
        {
            for (int i = 0; i < _encounter.Enemies.Count; i++)
             {
                 _encounter.Enemies[i].SetInfoBarActive(true);
                 _encounter.Enemies[i].SetBehaviorActive(true);
             }
        }

        private bool CheckForEndOfCombat()
        {
            bool allEnemiesKilled = true;

            for (int i = 0; i < _encounter.Enemies.Count; i++)
            {
                if (_encounter.Enemies[i].IsAlive() == true)
                {
                    allEnemiesKilled = false;
                }
            }
            
            return allEnemiesKilled;
        }
    }
}