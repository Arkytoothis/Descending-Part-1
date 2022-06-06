using System.Collections;
using System.Collections.Generic;
using DarkTonic.MasterAudio;
using UnityEngine;

namespace Descending.Gui
{
    public enum GameWindows { Pause, Treasure, Dungeon, Party, Dungeon_Exit, Number, None }
    
    public abstract class GameWindow : MonoBehaviour
    {
        [SerializeField] protected GameObject _container = null;
        [SerializeField, SoundGroupAttribute] protected string _openSound = "";
        [SerializeField, SoundGroupAttribute] protected string _closeSound = "";
        
        [SerializeField] protected bool _isOpen = false;

        public bool IsOpen => _isOpen;

        public abstract void Setup();
        public abstract void Open();
        public abstract void Close();
    }
}
