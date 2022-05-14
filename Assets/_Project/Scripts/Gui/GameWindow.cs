using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Descending.Gui
{
    public enum GameWindows { Pause, Treasure, Dungeon, Party, Encounter, Dungeon_Exit, Inn, Number, None }
    
    public abstract class GameWindow : MonoBehaviour
    {
        [SerializeField] protected GameObject _container = null;
        
        [SerializeField] protected bool _isOpen = false;

        public bool IsOpen => _isOpen;

        public abstract void Setup();
        public abstract void Open();
        public abstract void Close();
    }
}
