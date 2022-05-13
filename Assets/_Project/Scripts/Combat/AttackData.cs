using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Descending.Combat
{
    [System.Serializable]
    public class AttackData
    {
        [SerializeField] private AttackResults _result = AttackResults.None;
        [SerializeField] private int _attackRoll = 0;
        [SerializeField] private int _defenseRoll = 0;
        [SerializeField] private int _damage = 0;

        public AttackResults Result
        {
            get => _result;
            set => _result = value;
        }
        
        public int AttackRoll
        {
            get => _attackRoll;
            set => _attackRoll = value;
        }

        public int DefenseRoll
        {
            get => _defenseRoll;
            set => _defenseRoll = value;
        }

        public int Damage
        {
            get => _damage;
            set => _damage = value;
        }

        public AttackData()
        {
            _result = AttackResults.None;
            _attackRoll = 0;
            _defenseRoll = 0;
            _damage = 0;
        }
        
        public AttackData(AttackResults result, int attackRoll, int defenseRoll, int damage)
        {
            _result = result;
            _attackRoll = attackRoll;
            _defenseRoll = defenseRoll;
            _damage = damage;
        }
    }
}
