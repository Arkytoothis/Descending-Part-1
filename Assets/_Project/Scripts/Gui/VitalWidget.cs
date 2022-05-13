using System.Collections;
using System.Collections.Generic;
using Descending.Attributes;
using TMPro;
using UnityEngine;

namespace Descending.Gui.PcViewer
{
    public class VitalWidget : MonoBehaviour
    {
        [SerializeField] private TMP_Text _nameLabel = null;
        [SerializeField] private TMP_Text _valueLabel = null;

        public void SetVital(Attribute attribute, bool showLabel)
        {
            _nameLabel.SetText(attribute.Key);

            if (showLabel == true)
            {
                _valueLabel.SetText(attribute.Current + " / " + attribute.Maximum);
            }
        }
    }
}