using System.Collections;
using System.Collections.Generic;
using Descending.Core;
using Descending.Equipment;
using ScriptableObjectArchitecture;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Descending.Gui
{
    public class EquippedItemWidget : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private Image _icon = null;
        [SerializeField] private Image _border = null;
        [SerializeField] private TMP_Text _stackSizeLabel = null;
        [SerializeField] private Sprite _blankIcon = null;

        [SerializeField] private ItemEvent onDisplayItemTooltip = null;
        
        private Item _item = null;
        
        public void Setup()
        {
            Clear();
        }

        public void SetItem(Item item)
        {
            if (item != null && item.Name != "")
            {
                _item = item;
                _icon.sprite = _item.Icon;
                _stackSizeLabel.text = item.StackSize.ToString();

                _border.color = item.GetRarityColor();
            }
            else
            {
                Clear();
            }
        }

        public void Clear()
        {
            _item = null;
            _icon.sprite = _blankIcon;
            _stackSizeLabel.text = "";
            _border.color = Database.instance.Rarities.GetRarity(0).Color;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            onDisplayItemTooltip.Invoke(_item);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            onDisplayItemTooltip.Invoke(null);
        }
    }
}