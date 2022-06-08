using System;
using System.Collections;
using System.Collections.Generic;
using Descending.Combat;
using Descending.Core;
using Descending.Gui.Combat;
using ScriptableObjectArchitecture;
using TMPro;
using UnityEngine;

namespace Descending.Scene_Overworld.Gui
{
    public class InitiativePanel : MonoBehaviour
    {
        [SerializeField] private GameObject _heroWidgetPrefab = null;
        [SerializeField] private GameObject _enemyWidgetPrefab = null;
        [SerializeField] private Transform _initiativeWidgetsParent = null;

        private List<InitiativeWidget> _widgets = null;


    }
}