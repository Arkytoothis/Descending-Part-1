using System;
using System.Collections;
using System.Collections.Generic;
using Descending.Core;
using Descending.Encounters;
using Descending.Party;
using Descending.World;
using UnityEngine;
using UnityEngine.Serialization;

namespace Descending.Gui
{
    public class WindowManager : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _gameWindowPrefabs = null;
        [SerializeField] private Transform _gameWindowsParent = null;
        
        private List<GameWindow> _windows = null;

        public void Setup(PartyController party)
        {
            _gameWindowsParent.ClearTransform();
            _windows = new List<GameWindow>();
            
            for (int i = 0; i < _gameWindowPrefabs.Count; i++)
            {
                GameObject clone = Instantiate(_gameWindowPrefabs[i], _gameWindowsParent);
                clone.name = _gameWindowPrefabs[i].name;

                GameWindow window = clone.GetComponent<GameWindow>();
                window.Setup();
                
                _windows.Add(window);
            }

            ((VillageWindow)_windows[(int) GameWindows.Village]).SetParty(party);
            
            CLoseAll();
        }

        public void OpenWindow(int windowIndex)
        {
            CLoseAll();
            _windows[windowIndex].Open();
        }

        public void CloseWindow(int windowIndex)
        {
            _windows[windowIndex].Close();
        }

        public void CLoseAll()
        {
            for (int i = 0; i < _windows.Count; i++)
            {
                CloseWindow(i);
            }
        }
        
        public bool IsWindowOpen(int windowIndex)
        {
            return _windows[windowIndex].IsOpen;
        }

        public bool IsAnyWindowOpen()
        {
            for (int i = 0; i < _windows.Count; i++)
            {
                if (_windows[i].IsOpen == true)
                {
                    return true;
                }
            }

            return false;
        }

        public void OnEncounterTriggered(Encounter encounter)
        {
            CLoseAll();
            ((EncounterWindow) _windows[(int)GameWindows.Encounter]).LoadEncounter(encounter);
        }

        public void OnTriggerExitWindow(Dungeon dungeon)
        {
            CLoseAll();
            ((DungeonExitWindow) _windows[(int)GameWindows.Dungeon_Exit]).LoadDungeon(dungeon);
        }
    }
}
