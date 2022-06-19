using System.Collections;
using System.Collections.Generic;
using Descending.Abilities;
using Descending.Core;
using Descending.Equipment;
using ScriptableObjectArchitecture;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Descending.Gui
{
    public class ActionWidget : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        [SerializeField] private Image _icon = null;
        [SerializeField] private Image _border = null;
        [SerializeField] private TMP_Text _stackSizeLabel = null;
        [SerializeField] private Sprite _blankIcon = null;

        [SerializeField] private AbilityEvent onDisplayAbilityTooltip = null;
        [SerializeField] private AbilityEvent onSelectAbility = null;
        [SerializeField] private ItemEvent onDisplayItemTooltip = null;
        
        private Ability _ability = null;
        private Item _item = null;
        
        public void Setup()
        {
            Clear();
        }

        public void SetAbility(string key, Ability ability)
        {
            if (ability != null)
            {
                _ability = ability;
                _item = null;
                _icon.sprite = ability.Definition.Details.Icon;
                _stackSizeLabel.text = key;

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
            _item = null;
            _icon.sprite = _blankIcon;
            _stackSizeLabel.text = "";
            _border.color = Database.instance.Rarities.GetRarity(0).Color;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (_ability != null)
            {
                onDisplayAbilityTooltip.Invoke(_ability);
            }
            else if (_item != null)
            {
                onDisplayItemTooltip.Invoke(_item);
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            onDisplayAbilityTooltip.Invoke(null);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            onSelectAbility.Invoke(_ability);
        }
    }
}