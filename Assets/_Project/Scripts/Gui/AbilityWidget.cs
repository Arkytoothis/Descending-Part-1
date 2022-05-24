using System.Collections;
using System.Collections.Generic;
using Descending.Abilities;
using Descending.Core;
using ScriptableObjectArchitecture;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Descending.Gui
{
    public class AbilityWidget : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private Image _icon = null;
        [SerializeField] private Image _border = null;
        [SerializeField] private TMP_Text _stackSizeLabel = null;
        [SerializeField] private Sprite _blankIcon = null;

        [SerializeField] private AbilityEvent onDisplayAbilityTooltip = null;
        
        private Ability _ability = null;
        
        public void Setup()
        {
            Clear();
        }

        public void SetAbility(Ability ability)
        {
            if (ability != null && ability.Definition.Details.Name != "")
            {
                _ability = ability;
                _icon.sprite = ability.Definition.Details.Icon;
                _stackSizeLabel.text = "";

                _border.color = Color.white;
            }
            else
            {
                Clear();
            }
        }

        public void Clear()
        {
            _ability = null;
            _icon.sprite = _blankIcon;
            _stackSizeLabel.text = "";
            _border.color = Database.instance.Rarities.GetRarity(0).Color;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            onDisplayAbilityTooltip.Invoke(_ability);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            onDisplayAbilityTooltip.Invoke(null);
        }
    }
}