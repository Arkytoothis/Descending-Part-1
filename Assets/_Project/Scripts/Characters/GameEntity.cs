using System.Collections;
using System.Collections.Generic;
using Descending.Core;
using Descending.Equipment;
using UnityEngine;

namespace Descending.Characters
{
    public abstract class GameEntity : MonoBehaviour
    {
        protected bool _isAlive = false;

        public bool IsAlive1 => _isAlive;

        public abstract string GetName();
        public abstract void Damage(string attribute, int amount, DamageTypeDefinition damageType);
        public abstract void Restore(string attribute, int amount);
        public abstract void Death();
        public abstract bool IsAlive();
        //public abstract void UseAbility(Ability ability);
        public abstract void UseItem(Item item);
        public abstract void UseAccessory(int index);
        public abstract int RollDamage();
        public abstract void MeleeAttack();
    }
}