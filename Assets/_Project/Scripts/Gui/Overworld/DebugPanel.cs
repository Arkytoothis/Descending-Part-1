using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Descending.Scene_Overworld.Gui
{
    public class DebugPanel : MonoBehaviour
    {
        [SerializeField] private GameObject _container = null;

        public void Show()
        {
            _container.SetActive(true);
        }

        public void Hide()
        {
            _container.SetActive(false);
        }
        
        public void Setup()
        {
            
        }
    }
}
