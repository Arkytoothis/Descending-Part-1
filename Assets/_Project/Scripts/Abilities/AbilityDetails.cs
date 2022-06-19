﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Descending.Core;
using Sirenix.OdinInspector;
using System.Text;
using Descending.Attributes;
using Descending.Characters;

namespace Descending.Abilities
{
    [System.Serializable]
    public class AbilityDetails
    {
        [HorizontalGroup("Split", 0.5f)]
        [SerializeField, HideLabel, PreviewField(50), BoxGroup("Split/Icon")]
        private Sprite _icon = null;

        [SerializeField] private AbilityType _abilityType = AbilityType.None;
        [SerializeField] private string _name = "";
        [SerializeField] private string _key = "";
        [SerializeField] private string _description = "";
        [SerializeField] private int _cooldown = 0;
        [SerializeField] private AttributeDefinition _resourceAttribute = null;
        [SerializeField] private int _resourceAmount = 0;
        [SerializeField] private SkillDefinition _skill = null;
        [SerializeField] private int _minimumSkill = 0;
        [SerializeField] private int _actionsToUse = 1;
        
        public string Name => _name;
        public string Key => _key;
        public string Description => _description;
        public Sprite Icon => _icon;
        public int Cooldown => _cooldown;
        public AbilityType AbilityType => _abilityType;
        public AttributeDefinition ResourceAttribute => _resourceAttribute;
        public int ResourceAmount => _resourceAmount;
        public SkillDefinition Skill => _skill;
        public int MinimumSkill => _minimumSkill;
        public int ActionsToUse => _actionsToUse;

        public string GetTooltipText()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Ability Type ").Append(_abilityType).Append("\n");
            sb.Append("Cooldown ").Append(_cooldown).Append("\n");
            sb.Append("Description ").Append(_description).Append("\n");
            sb.Append("Resource ").Append(_resourceAttribute.Name).Append(" ").Append(_resourceAmount).Append("\n\n");
            sb.Append("Skill ").Append(_skill.Name).Append(" ").Append(_minimumSkill).Append("\n\n");
            sb.Append("Actions ").Append(_actionsToUse).Append("\n");

            return sb.ToString();
        }
    }
}