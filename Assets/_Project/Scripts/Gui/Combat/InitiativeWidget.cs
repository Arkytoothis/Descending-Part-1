using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Descending.Gui.Combat
{
    public abstract class InitiativeWidget : MonoBehaviour
    {
        [SerializeField] protected TMP_Text _nameLabel = null;
        [SerializeField] protected int _index = -1;
    }
}
