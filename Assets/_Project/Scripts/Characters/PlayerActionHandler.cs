using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Descending.Player
{
    public class PlayerActionHandler : MonoBehaviour
    {
        [SerializeField] private float _attackDelay = 1f;

        private bool _inputEnabled = true;
        private Animator _animator = null;
        private bool _canUseRightHand = true;
        private bool _blocking = false;
        private float _nextAttack = 0f;
        
        public void Setup()
        {
            _animator = GetComponentInChildren<Animator>();
        }

        private void Update()
        {
            if (_inputEnabled == false) return;
            
            if (Input.GetMouseButton(0) && _canUseRightHand == true && Time.time > _nextAttack)
            {
                _nextAttack = Time.time + _attackDelay;
                RightHandAction();
            }
            
            if (Input.GetMouseButtonDown(1) && _blocking == false)
            {
                Block();
                
            }

            if (Input.GetMouseButtonUp(1) && _blocking == true)
            {
                Unblock();
            }
        }

        private void RightHandAction()
        {
            if (_blocking == true)
            {
                Unblock();
            }
            
            _canUseRightHand = false;
            _animator.SetTrigger("RightHand");
            StartCoroutine(EnableRightHandAction(_animator.GetCurrentAnimatorStateInfo(1).normalizedTime));
        }

        private void Block()
        {
            _blocking = true;
            _animator.SetBool("Blocking", _blocking);
        }

        private void Unblock()
        {
            _blocking = false;
            _animator.SetBool("Blocking", _blocking);
        }
        
        private IEnumerator EnableRightHandAction(float delay)
        {
            yield return new WaitForSeconds(delay);
            _canUseRightHand = true;
        }

        public void SetInputEnabled(bool inputEnabled)
        {
            _inputEnabled = inputEnabled;
        }
    }
}