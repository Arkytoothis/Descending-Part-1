using System.Collections;
using System.Collections.Generic;
using Descending.World;
using ScriptableObjectArchitecture;
using TMPro;
using UnityEngine;

namespace Descending.Gui
{
    public class DungeonWindow : GameWindow
    {
        [SerializeField] private TMP_Text _nameLabel = null;

        [SerializeField] private DungeonEvent onStartDungeon = null;

        private Dungeon _dungeon = null;
        
        public override void Setup()
        {
            Close();
        }

        public override void Open()
        {
            Time.timeScale = 0;
            _isOpen = true;
            _container.SetActive(true);
        }

        public override void Close()
        {
            Time.timeScale = 1;
            _isOpen = false;
            _container.SetActive(false);

            if (_dungeon != null)
            {
                _dungeon.EndInteraction();
            }
        }

        public void CloseButtonClick()
        {
            Close();
        }

        public void OnLoadDungeon(Dungeon dungeon)
        {
            _dungeon = dungeon;
            
            if (dungeon == null) return;
            
            _nameLabel.text = dungeon.Definition.Name;
            Open();
        }

        public void StartDungeonButtonClick()
        {
            onStartDungeon.Invoke(_dungeon);
        }
    }
}
