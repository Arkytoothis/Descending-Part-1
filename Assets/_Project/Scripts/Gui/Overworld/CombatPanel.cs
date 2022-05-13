using System;
using System.Collections;
using System.Collections.Generic;
using Descending.Combat;
using ScriptableObjectArchitecture;
using TMPro;
using UnityEngine;

namespace Descending.Scene_Overworld.Gui
{
    public class CombatPanel : MonoBehaviour
    {
        [SerializeField] private GameObject _container = null;
        [SerializeField] private TMP_Text _statusLabel = null;
        [SerializeField] private TMP_Text _heroesLabel = null;
        [SerializeField] private TMP_Text _enemiesLabel = null;
        [SerializeField] private float _syncDelay = 0.2f;
        
        [SerializeField] private BoolEvent onEndCombat_Gui = null;

        private CombatParameters _combatParameters = null;
        
        public void Show()
        {
            _container.SetActive(true);
        }

        public void Hide()
        {
            _container.SetActive(false);
        }

        public void Setup(CombatParameters parameters)
        {
            _combatParameters = parameters;
            if (_combatParameters == null) return;

            StartCoroutine(SyncDataCoroutine());
        }

        public void EndCombatButtonClick()
        {
            onEndCombat_Gui.Invoke(true);
        }

        public void SyncData()
        {
            _statusLabel.SetText("Combat Started");
            _heroesLabel.SetText("Heroes: " + _combatParameters.Party.PartyData.Heroes.Count + " Total Life: " + GetTotalHeroLife());
            _enemiesLabel.SetText("Enemies: " + _combatParameters.Encounter.Enemies.Count + " Total Life: " + GetTotalEnemyLife());
        }

        public void OnSyncData(bool b)
        {
            SyncData();
        }

        private IEnumerator SyncDataCoroutine()
        {
            while (true)
            {
                yield return new WaitForSecondsRealtime(_syncDelay);
                SyncData();
            }
        }

        private int GetTotalHeroLife()
        {
            int heroLife = 0;
            for (int i = 0; i < _combatParameters.Party.PartyData.Heroes.Count; i++)
            {
                heroLife += _combatParameters.Party.PartyData.Heroes[i].Attributes.GetVital("Life").Current;
            }

            return heroLife;
        }

        private int GetTotalEnemyLife()
        {
            int enemyLife = 0;
            
            for (int i = 0; i < _combatParameters.Encounter.Enemies.Count; i++)
            {
                enemyLife += _combatParameters.Encounter.Enemies[i].Attributes.GetVital("Life").Current;
            }

            return enemyLife;
        }
    }
}