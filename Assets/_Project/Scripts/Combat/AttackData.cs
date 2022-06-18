using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Descending.Combat
{
    [System.Serializable]
    public class AttackData
    {
        public int AttackRoll = 0;
        public int DefenseRoll = 0;
        public int Damage = 0;
        public AttackResults Result = AttackResults.None;

        public AttackData()
        {
            AttackRoll = 0;
            DefenseRoll = 0;
            Damage = 0;
            Result = AttackResults.None;
        }
    }
}
