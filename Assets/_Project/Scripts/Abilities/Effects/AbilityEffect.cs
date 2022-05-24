using Descending.Characters;
using Descending.Core;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

namespace Descending.Abilities
{
    [System.Serializable]
    public abstract class AbilityEffect
    {
        [SerializeField] protected AbilityDefinition _ability = null;
        [SerializeField] protected AbilityEffectType _effectType = AbilityEffectType.None;
        [SerializeField] protected AbilityEffectAffects _affects = AbilityEffectAffects.None;

        public AbilityEffectType EffectType { get => _effectType; }
        public AbilityEffectAffects Affects { get => _affects; set => _affects = value; }

        public virtual string GetTooltipText() { return ""; }
        public virtual void Process(GameEntity user, List<GameEntity> targets) { }
    }
}