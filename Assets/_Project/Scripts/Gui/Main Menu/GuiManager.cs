using System.Collections;
using System.Collections.Generic;
using ScriptableObjectArchitecture;
using UnityEngine;

namespace Descending.Scene_MainMenu.Gui
{
    public class GuiManager : MonoBehaviour
    {
        [SerializeField] private PartyPanel _partyPanel = null;
        
        [SerializeField] private BoolEvent onGenerateParty = null;
        [SerializeField] private BoolEvent onGenerateFavoriteParty = null;
        [SerializeField] private BoolEvent onStartGame = null;
        
        public void Setup()
        {
            _partyPanel.Setup();
        }

        public void RandomizeParty_ButtonClick()
        {
            onGenerateParty.Invoke(true);
        }

        public void GenerateFavoriteParty_ButtonClick()
        {
            onGenerateFavoriteParty.Invoke(true);
        }

        public void StartGame_ButtonClick()
        {
            onStartGame.Invoke(true);
        }
    }
}