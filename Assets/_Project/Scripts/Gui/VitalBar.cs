using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Descending.Gui
{
    public class VitalBar : MonoBehaviour
    {
        [SerializeField] private Image _foreground = null;
        [SerializeField] private TMP_Text _valueLabel = null;
        [SerializeField] private Color _textColor = Color.white;
        [SerializeField] private Color _disabledTextColor = Color.gray;
        [SerializeField] private bool _billboard = false;
        
        private Camera _camera = null;

        private void Awake()
        {
            _camera = Camera.main;
        }
        
        void Update()
        {
            if (_billboard == true)
            {
                Vector3 rot = _camera.transform.rotation.eulerAngles;
                rot.z = 0;
                transform.rotation = Quaternion.Euler(rot);
            }
        }

        public void SetValues(int current, int maximum, bool showLabel)
        {
            if (maximum != 0)
            {
                float value = (float)current / (float)maximum;
                _foreground.fillAmount = value;
                _valueLabel.color = _textColor;
            }
            else
            {
                _foreground.fillAmount = 0;
                _valueLabel.color = _disabledTextColor;
            }

            if (showLabel == true)
            {
                _valueLabel.text = current + "/" + maximum;
            }
            else
            {
                _valueLabel.text = "";
            }
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}