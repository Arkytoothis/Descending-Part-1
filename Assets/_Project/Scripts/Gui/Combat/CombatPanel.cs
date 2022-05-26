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
        [SerializeField] private TMP_Text _mouseTile = null;
        [SerializeField] private InitiativePanel _initiativePanel = null;
        
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
            
            SyncData();
            _initiativePanel.Setup(_combatParameters);
        }
        
        public void EndCombatButtonClick()
        {
            onEndCombat_Gui.Invoke(true);
        }

        private void SyncData()
        {
            _statusLabel.SetText("Combat Started");
            _heroesLabel.SetText("Heroes: " + _combatParameters.Party.PartyData.Heroes.Count + " Total Life: " + GetTotalHeroLife());
            _enemiesLabel.SetText("Enemies: " + _combatParameters.Encounter.Enemies.Count + " Total Life: " + GetTotalEnemyLife());
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

        public void DisplayMouseTile(CombatTile tile)
        {
            if (tile != null)
            {
                string text = "X: " + tile.X + " Y: " + tile.Y;
                if (tile.Entity != null)
                {
                    text += "\n" + tile.Entity.GetName();
                }

                _mouseTile.SetText(text);
            }
            else
            {
                _mouseTile.SetText("");
            }
        }
    }
}