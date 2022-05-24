using Descending.Characters;
using Descending.Core;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Descending.Abilities
{
    [System.Serializable]
    public class RestoreOverTimeEffect : AbilityEffect
    {
        [SerializeField] private string _attribute = "";
        [SerializeField] private int _minimumValue = 0;
        [SerializeField] private int _maximumValue = 0;
        [SerializeField] private int _minimumDuration = 0;
        [SerializeField] private int _maximumDuration = 0;

        public string Attribute { get => _attribute; }
        public int MinimumValue { get => _minimumValue; }
        public int MaximumValue { get => _maximumValue; }
        public int MinimumDuration { get => _minimumDuration; }
        public int MaximumDuration { get => _maximumDuration; }

        public override string GetTooltipText()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Restores ").Append(_minimumValue).Append(" - ").Append(_maximumValue).Append(" ").Append(_attribute);
            sb.Append(" for ").Append(_minimumDuration).Append(" - ").Append(_maximumDuration).Append(" rounds\n");

            return sb.ToString();
        }

        public override void Process(GameEntity user, List<GameEntity> targets)
        {
            foreach (GameEntity character in targets)
            {
                // if (character.GetType() == typeof(PlayerCharacter))
                // {
                //     PlayerCharacter pc = (PlayerCharacter)character;
                //
                //     if (pc != null)
                //     {
                //         int amount = Random.Range(_minimumValue, _maximumValue + 1);
                //         pc.RestoreDamage(DerivedAttribute.Life, amount, false);
                //     }
                // }
                // else if (character.GetType() == typeof(Enemy))
                // {
                //     Enemy enemy = (Enemy)character;
                //
                //     if (enemy != null)
                //     {
                //         int amount = Random.Range(_minimumValue, _maximumValue + 1);
                //         enemy.RestoreDamage(DerivedAttribute.Life, amount, false);
                //     }
                // }
            }
        }
    }
}