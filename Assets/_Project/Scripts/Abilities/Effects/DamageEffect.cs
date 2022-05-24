using Descending.Characters;
using Descending.Core;
using System.Collections.Generic;
using System.Text;
using Descending.Attributes;
using UnityEngine;

namespace Descending.Abilities
{
    [System.Serializable]
    public class DamageEffect : AbilityEffect
    {
        [SerializeField] private DamageTypeDefinition _damageType = null;
        [SerializeField] private AttributeDefinition _attribute = null;
        [SerializeField] private int _minimumValue = 0;
        [SerializeField] private int _maximumValue = 0;

        public DamageTypeDefinition DamageType { get => _damageType; }
        public AttributeDefinition Attribute { get => _attribute; }
        public int MinimumValue { get => _minimumValue; }
        public int MaximumValue { get => _maximumValue; }

        public override string GetTooltipText()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Causes ").Append(_minimumValue).Append(" - ").Append(_maximumValue).Append(" ").Append(_damageType.Name).Append(" damage\n");

            return sb.ToString();
        }

        public override void Process(GameEntity user, List<GameEntity> targets)
        {
            if (_affects == AbilityEffectAffects.User)
            {
                // if (user.GetType() == typeof(PlayerCharacter))
                // {
                //     PlayerCharacter pc = (PlayerCharacter)user;
                //
                //     if (pc != null)
                //     {
                //         int amount = Random.Range(_minimumValue, _maximumValue + 1);
                //         pc.TakeDamage(_attribute, _damageType, amount, false);
                //     }
                // }
                // else if (user.GetType() == typeof(Enemy))
                // {
                //     Enemy enemy = (Enemy)user;
                //
                //     if (enemy != null)
                //     {
                //         int amount = Random.Range(_minimumValue, _maximumValue + 1);
                //         enemy.TakeDamage(_attribute, _damageType, amount, false);
                //     }
                // }
            }
            else if (_affects == AbilityEffectAffects.Target)
            {
                // foreach (BaseCharacter character in targets)
                // {
                //     if (character.GetType() == typeof(PlayerCharacter))
                //     {
                //         PlayerCharacter pc = (PlayerCharacter)character;
                //
                //         if (pc != null)
                //         {
                //             int amount = Random.Range(_minimumValue, _maximumValue + 1);
                //             pc.TakeDamage(_attribute, _damageType, amount, false);
                //         }
                //     }
                //     else if (character.GetType() == typeof(Enemy))
                //     {
                //         Enemy enemy = (Enemy)character;
                //
                //         if (enemy != null)
                //         {
                //             int amount = Random.Range(_minimumValue, _maximumValue + 1);
                //             enemy.TakeDamage(_attribute, _damageType, amount, false);
                //         }
                //     }
                // }
            }
        }
    }
}