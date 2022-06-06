using System.Collections;
using System.Collections.Generic;
using Descending.Characters;
using Descending.Core;
using Descending.Scene_Overworld.Gui;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Descending.Gui
{
    public class HeroWidget : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private TMP_Text _levelLabel = null;
        [SerializeField] private TMP_Text _nameLabel = null;
        [SerializeField] private RawImage _portraitImage = null;
        [SerializeField] private VitalBarDictionary _vitalWidgets = null;
        [SerializeField] private VitalBar _experienceBar = null;
        [SerializeField] private Image _border = null;
        [SerializeField] private Color _selectedColor = Color.white;
        [SerializeField] private Color _deselectedColor = Color.white;

        private Hero _hero = null;
        private int _index = -1;
        private PartyPanel _partyPanel = null;
        
        public void SetHero(PartyPanel partyPanel, Hero hero, int index)
        {
            _partyPanel = partyPanel;
            _hero = hero;
            _index = index;

            if (_hero == null) return;
            SyncData();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            _partyPanel.SelectHero(_index);
        }

        public void SyncData()
        {
            _levelLabel.text = _hero.HeroData.Level.ToString();
            _nameLabel.text = _hero.HeroData.Name.ShortName;

            if (_hero.Portrait != null)
            {
                _portraitImage.texture = _hero.Portrait.RtClose;
            }
            
            _vitalWidgets["Armor"].SetValues(_hero.Attributes.GetVital("Armor").Current, _hero.Attributes.GetVital("Armor").Maximum, false);
            _vitalWidgets["Life"].SetValues(_hero.Attributes.GetVital("Life").Current, _hero.Attributes.GetVital("Life").Maximum, false);
            _vitalWidgets["Stamina"].SetValues(_hero.Attributes.GetVital("Stamina").Current, _hero.Attributes.GetVital("Stamina").Maximum, false);
            _vitalWidgets["Magic"].SetValues(_hero.Attributes.GetVital("Magic").Current, _hero.Attributes.GetVital("Magic").Maximum, false);
            
            _experienceBar.SetValues(_hero.HeroData.Experience, _hero.HeroData.ExpToNextLevel, false);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
        }

        public void OnPointerExit(PointerEventData eventData)
        {
        }

        public void Select()
        {
            _border.color = _selectedColor;
        }

        public void Deselect()
        {
            _border.color = _deselectedColor;
        }
    }
}
