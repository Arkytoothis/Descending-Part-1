using System.Collections;
using System.Collections.Generic;
using Descending.Characters;
using Descending.Enemies;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Descending.Gui
{
    public class CurrentEntityPanel : MonoBehaviour
    {
        [SerializeField] private RawImage _rawPortrait = null;
        [SerializeField] private Image _imagePortrait = null;
        [SerializeField] private TMP_Text _nameLabel = null;
        [SerializeField] private TMP_Text _actionsLabel = null;
        [SerializeField] private TMP_Text _quickActionsLabel = null;
        [SerializeField] private VitalBar _armorBar = null;
        [SerializeField] private VitalBar _lifeBar = null;
        [SerializeField] private VitalBar _staminaBar = null;
        [SerializeField] private VitalBar _magicBar = null;

        private Hero _hero = null;
        private Enemy _enemy = null;
        
        public void SetHero(Hero hero)
        {
            _hero = hero;
            _enemy = null;
            _rawPortrait.enabled = true;
            _rawPortrait.texture = hero.Portrait.RtClose;
            _imagePortrait.enabled = false;
            _nameLabel.SetText( hero.HeroData.Name.FullName);
            _actionsLabel.SetText("Actions " + hero.Attributes.GetVital("Actions").Current + "/" + hero.Attributes.GetVital("Actions").Maximum);
            _quickActionsLabel.SetText("Quick Actions " + hero.Attributes.GetVital("Quick Actions").Current + "/" + hero.Attributes.GetVital("Quick Actions").Maximum);
            _armorBar.SetValues(hero.Attributes.GetVital("Armor").Current, hero.Attributes.GetVital("Armor").Maximum, true);
            _lifeBar.SetValues(hero.Attributes.GetVital("Life").Current, hero.Attributes.GetVital("Life").Maximum, true);
            _staminaBar.SetValues(hero.Attributes.GetVital("Stamina").Current, hero.Attributes.GetVital("Stamina").Maximum, true);
            _magicBar.SetValues(hero.Attributes.GetVital("Magic").Current, hero.Attributes.GetVital("Magic").Maximum, true);
        }

        public void SetEnemy(Enemy enemy)
        {
            _hero = null;
            _enemy = enemy;
            _imagePortrait.enabled = true;
            _imagePortrait.sprite = enemy.EnemyDefinition.Icon;
            _rawPortrait.enabled = false;
            _nameLabel.SetText(enemy.EnemyDefinition.Name);
            _actionsLabel.SetText("Actions " + enemy.Attributes.GetVital("Actions").Current + "/" + enemy.Attributes.GetVital("Actions").Maximum);
            _quickActionsLabel.SetText("Quick Actions " + enemy.Attributes.GetVital("Quick Actions").Current + "/" + enemy.Attributes.GetVital("Quick Actions").Maximum);
            _armorBar.SetValues(enemy.Attributes.GetVital("Armor").Current, enemy.Attributes.GetVital("Armor").Maximum, true);
            _lifeBar.SetValues(enemy.Attributes.GetVital("Life").Current, enemy.Attributes.GetVital("Life").Maximum, true);
            _staminaBar.SetValues(enemy.Attributes.GetVital("Stamina").Current, enemy.Attributes.GetVital("Stamina").Maximum, true);
            _magicBar.SetValues(enemy.Attributes.GetVital("Magic").Current, enemy.Attributes.GetVital("Magic").Maximum, true);
        }

        public void OnSyncData(bool b)
        {
            if (_hero != null)
            {
                _actionsLabel.SetText("Actions " + _hero.Attributes.GetVital("Actions").Current + "/" + _hero.Attributes.GetVital("Actions").Maximum);
                _quickActionsLabel.SetText("Quick Actions " + _hero.Attributes.GetVital("Quick Actions").Current + "/" + _hero.Attributes.GetVital("Quick Actions").Maximum);
                _armorBar.SetValues(_hero.Attributes.GetVital("Armor").Current, _hero.Attributes.GetVital("Armor").Maximum, true);
                _lifeBar.SetValues(_hero.Attributes.GetVital("Life").Current, _hero.Attributes.GetVital("Life").Maximum, true);
                _staminaBar.SetValues(_hero.Attributes.GetVital("Stamina").Current, _hero.Attributes.GetVital("Stamina").Maximum, true);
                _magicBar.SetValues(_hero.Attributes.GetVital("Magic").Current, _hero.Attributes.GetVital("Magic").Maximum, true);
            }
            else if (_enemy != null)
            {
                _actionsLabel.SetText("Actions " + _enemy.Attributes.GetVital("Actions").Current + "/" + _enemy.Attributes.GetVital("Actions").Maximum);
                _quickActionsLabel.SetText("Quick Actions " + _enemy.Attributes.GetVital("Quick Actions").Current + "/" + _enemy.Attributes.GetVital("Quick Actions").Maximum);
                _armorBar.SetValues(_enemy.Attributes.GetVital("Armor").Current, _enemy.Attributes.GetVital("Armor").Maximum, true);
                _lifeBar.SetValues(_enemy.Attributes.GetVital("Life").Current, _enemy.Attributes.GetVital("Life").Maximum, true);
                _staminaBar.SetValues(_enemy.Attributes.GetVital("Stamina").Current, _enemy.Attributes.GetVital("Stamina").Maximum, true);
                _magicBar.SetValues(_enemy.Attributes.GetVital("Magic").Current, _enemy.Attributes.GetVital("Magic").Maximum, true);
            }
        }
    }
}