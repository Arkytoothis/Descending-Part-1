using System;
using System.Collections;
using System.Collections.Generic;
using Descending.Characters;
using Descending.Core;
using Descending.Equipment;
using Descending.Gui;
using HighlightPlus;
using ScriptableObjectArchitecture;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Descending.Enemies
{
    public class Enemy : GameEntity
    {
        [SerializeField] private EnemyDefinition _enemyDefinition = null;
        [SerializeField] private Animator _animator;
        [SerializeField] private int _level = 0;
        [SerializeField] private AttributesController _attributes = null;
        [SerializeField] private Collider _collider = null;
        [SerializeField] private VitalBar _lifeBar = null;
        [SerializeField] private Transform _hitEffectTransform = null;
        [SerializeField] private HighlightEffect _highlightEffect = null;
        
        [SerializeField] private IntEvent onAddExperience = null;
        [SerializeField] private IntEvent onHighlightEnemy_Gui = null;
        
        public EnemyDefinition EnemyDefinition => _enemyDefinition;
        public AttributesController Attributes => _attributes;
        public int Level => _level;
        public Transform HitEffectTransform => _hitEffectTransform;

        public void Setup(EnemyDefinition definition, Animator animator, int level, int index)
        {
            _listIndex = index;
            _enemyDefinition = definition;
            _animator = animator;
            _level = level;
            _attributes.Setup(_enemyDefinition);    
            _lifeBar.SetValues(_attributes.GetVital("Life").Current, _attributes.GetVital("Life").Maximum, false);
            SetInfoBarActive(false);
        }

        public override void SetListIndex(int index)
        {
            _listIndex = index;
        }

        public override void SetInitiativeIndex(int index)
        {
            _initiativeIndex = index;
        }
        
        public override string GetName()
        {
            return _enemyDefinition.Name;
        }

        public override void Damage(string attribute, int amount, DamageTypeDefinition damageType)
        {
            if (IsAlive() == false) return;
            
            //Debug.Log(amount + " damage taken");
            _attributes.Vitals["Life"].Damage(amount);
            _lifeBar.SetValues(_attributes.GetVital("Life").Current, _attributes.GetVital("Life").Maximum, false);
            
            if (_attributes.Vitals["Life"].Current <= 0)
            {
                Death();
                _lifeBar.gameObject.SetActive(false);
            }
            else
            {
                string sound = _enemyDefinition.GetWoundSound();
                //MasterAudio.PlaySound3DAtTransform(sound, transform, .3f, 1f);
            }
        }

        public override void Restore(string attribute, int amount)
        {
        }

        public override void Death()
        {
            //Debug.Log(GetName() + " has died");
            _animator.SetTrigger("isDead");
            _collider.enabled = false;
            onAddExperience.Invoke(_enemyDefinition.ExpValue);
        }

        public override bool IsAlive()
        {
            return _attributes.Vitals["Life"].Current > 0;
        }

        public override void UseItem(Item item)
        {
        }

        public override void UseAccessory(int index)
        {
        }

        public void SetInfoBarActive(bool active)
        {
            _lifeBar.gameObject.SetActive(active);
        }
        
        public override int RollDamage()
        {
            int min = 0;
            int max = 4;

            return Random.Range(min, max + 1);
        }

        public override void MeleeAttack()
        {
            _animator.SetTrigger("Attack");
            
            if (Random.Range(0, 100) < 50)
            {
                string attackSound = _enemyDefinition.GetAttackSound();
                //MasterAudio.PlaySound3DAtTransform(attackSound, transform, .2f, 1f);
            }
            
            string swingSound = "sword_swing_" + Random.Range(1, 4);
            //MasterAudio.PlaySound3DAtTransform(swingSound, transform, .15f, 1f);
        }

        private void OnMouseEnter()
        {
            _highlightEffect.highlighted = true;
            onHighlightEnemy_Gui.Invoke(_initiativeIndex);
        }

        private void OnMouseExit()
        {
            _highlightEffect.highlighted = false;
            onHighlightEnemy_Gui.Invoke(-1);
        }

        public void Highlight()
        {
            _highlightEffect.highlighted = true;
        }

        public void Unhighlight()
        {
            _highlightEffect.highlighted = false;
        }

        public override void UseActions(int amount)
        {
            _attributes.Vitals["Actions"].Damage(amount);
        }
    }
}
