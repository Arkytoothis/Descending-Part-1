using System;
using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

namespace Descending.Characters
{
    public class CharacterPathfinder : MonoBehaviour
    {
        [SerializeField] private Animator _animator = null;
        private Rigidbody _rigidbody = null;
        private RichAI _richAi = null;
        private Seeker _seeker = null;
        private AIDestinationSetter _destinationSetter = null;
        
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _richAi = GetComponent<RichAI>();
            _seeker = GetComponent<Seeker>();
            _destinationSetter = GetComponent<AIDestinationSetter>();
        }

        public void SetDestination(Transform transformTarget)
        {
            _destinationSetter.target = transformTarget;
            Debug.Log("Target Set: " + transformTarget.gameObject.name);
        }

        private void Update()
        {
            _animator.SetFloat("Blend", _rigidbody.velocity.magnitude);
        }
    }
}
