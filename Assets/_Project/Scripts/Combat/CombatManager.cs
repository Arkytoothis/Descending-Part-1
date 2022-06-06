using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using DarkTonic.MasterAudio;
using ScriptableObjectArchitecture;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Descending.Combat
{
    public class CombatManager : MonoBehaviour
    {
        [SerializeField] private CombatGrid _grid = null;
        [SerializeField, Playlist] private string _combatPlaylist = "";
        [SerializeField, Playlist] private string _defaultPlaylist = "";
        [SerializeField] private CinemachineVirtualCamera _camera = null;
        [SerializeField] private CombatParametersEvent onSyncCombatParameters = null;
        [SerializeField] private BoolEvent onEndCombat_Manager = null;
        [SerializeField] private IntEvent onSelectInitiative = null;
        
        private CombatParameters _parameters = null;
        private bool _combatStarted = false;
        private int _currentInitiativeIndex = -1;
        
        public void Setup()
        {
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                StartCoroutine(ProcessTurn(0.1f));
            }
        }

        public void StartCombat(CombatParameters combatParameters)
        {
            //Debug.Log("Starting Combat");
            MasterAudio.StartPlaylist(_combatPlaylist);
            _combatStarted = true;
            _parameters = combatParameters;
            _parameters.Party.CombatStarted(combatParameters);
            
            _grid.StartCombat(_parameters);
            
            LoadHeroes();
            LoadEnemies();
            
            RollInitiative();
            
            onSyncCombatParameters.Invoke(_parameters);
            StartCoroutine(ProcessTurn(0.1f));
        }

        private IEnumerator ProcessTurn(float delay)
        {
            yield return new WaitForSeconds(delay);
            _currentInitiativeIndex++;

            if (_currentInitiativeIndex >= _parameters.InitiativeList.Count) _currentInitiativeIndex = 0;
            
            if (_parameters.InitiativeList[_currentInitiativeIndex].Hero != null)
            {
                ProcessHeroTurn();
            }
            else if (_parameters.InitiativeList[_currentInitiativeIndex].Enemy != null)
            {
                ProcessEnemyTurn();
            }
            
            onSelectInitiative.Invoke(_currentInitiativeIndex);
        }

        private void ProcessEnemyTurn()
        {
            _grid.HighlightMoveRange(_parameters.InitiativeList[_currentInitiativeIndex].Enemy.transform.position, 3);
            //_grid.HighlightAttackRange(_parameters.InitiativeList[_currentInitiativeIndex].Enemy.transform.position, 1.5f);
            SelectEnemy(_parameters.InitiativeList[_currentInitiativeIndex].Enemy.ListIndex);
            _camera.m_Follow = _parameters.InitiativeList[_currentInitiativeIndex].Enemy.transform;
            _camera.m_LookAt = _parameters.InitiativeList[_currentInitiativeIndex].Enemy.transform;
            
            StartCoroutine(ProcessTurn(1f));
        }

        private void ProcessHeroTurn()
        {
            int movement = _parameters.InitiativeList[_currentInitiativeIndex].Hero.Attributes.GetVital("Movement").Current;
                
            _grid.HighlightMoveRange(_parameters.InitiativeList[_currentInitiativeIndex].Hero.transform.position, movement);
            //_grid.HighlightAttackRange(_parameters.InitiativeList[_currentInitiativeIndex].Hero.transform.position, 1.5f);
            SelectHero(_parameters.InitiativeList[_currentInitiativeIndex].Hero.HeroData.ListIndex);
            _camera.m_Follow = _parameters.InitiativeList[_currentInitiativeIndex].Hero.transform;
            _camera.m_LookAt = _parameters.InitiativeList[_currentInitiativeIndex].Hero.transform;
        }
        
        private void EndCombat()
        {
            //Debug.Log("Ending Combat");
            MasterAudio.StartPlaylist(_defaultPlaylist);
            _parameters.Party.OnCombatEnded(true);
            Destroy(_parameters.Encounter.gameObject);
            _parameters.Encounter = null;
            _parameters.InitiativeList.Clear();
            _grid.EndCombat();
            
            for (int i = 0; i < _parameters.Party.PartyData.Heroes.Count; i++)
            {
                _parameters.Party.PartyData.Heroes[i].LifeBar.Hide();
            }
            
            _parameters.Party.SetCameraTarget(0);
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

        public void SelectHero(int index)
        {
            DeselectEnemies();
            DeselectHeroes();
            _parameters.Party.PartyData.Heroes[index].Select();
        }

        public void SelectEnemy(int index)
        {
            DeselectEnemies();
            DeselectHeroes();
            _parameters.Encounter.Enemies[index].Select();
        }

        private void DeselectHeroes()
        {
            for (int i = 0; i < _parameters.Party.PartyData.Heroes.Count; i++)
            {
                _parameters.Party.PartyData.Heroes[i].Deselect();
            }
        }

        private void DeselectEnemies()
        {
            for (int i = 0; i < _parameters.Encounter.Enemies.Count; i++)
            {
                _parameters.Encounter.Enemies[i].Deselect();
            }
        }

        public void MoveToTile(CombatTile tile)
        {
            //Debug.Log("Moving to tile X: " + tile.X + " Y: " + tile.Y);
            _parameters.InitiativeList[_currentInitiativeIndex].Hero.CurrentTile.SetGameEntity(null);
            
            if (_parameters.InitiativeList[_currentInitiativeIndex].Hero != null)
            {
                _parameters.InitiativeList[_currentInitiativeIndex].Hero.SnapToTile(tile);
                tile.SetGameEntity(_parameters.InitiativeList[_currentInitiativeIndex].Hero);
                
                _grid.HighlightMoveRange(_parameters.InitiativeList[_currentInitiativeIndex].Hero.CurrentTile.transform.position, 3);
                //_grid.HighlightAttackRange(_parameters.InitiativeList[_currentInitiativeIndex].Hero.CurrentTile.transform.position, 1.5f);
            }
        }
    }
}