using System.Collections;
using System.Collections.Generic;
using Descending.Attributes;
using TMPro;
using UnityEngine;

namespace Descending.Gui
{
    public class AttributeWidget : MonoBehaviour
    {
        [SerializeField] private TMP_Text _nameLabel = null;
        [SerializeField] private TMP_Text _valueLabel = null;

        public void SetAttribute(Attribute attribute)
        {
            _nameLabel.SetText(attribute.Key);
            _valueLabel.SetText(attribute.Current.ToString());
        }

        public void SetStatisticPoints(Attribute attribute)
        {
            _nameLabel.SetText(attribute.Key);
            _valueLabel.SetText(attribute.Current.ToString());
        }

        public void SetStatisticPercentage(Attribute attribute)
        {
            _nameLabel.SetText(attribute.Key);
            _valueLabel.SetText(attribute.Current + " %");
        }
    }
}