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
        
        [SerializeField] private BoolEvent onEndCombat_Gui = null;
        
        public void Show()
        {
            _container.SetActive(true);
        }

        public void Hide()
        {
            _container.SetActive(false);
        }
        
        public void EndCombatButtonClick()
        {
            onEndCombat_Gui.Invoke(true);
        }
    }
}