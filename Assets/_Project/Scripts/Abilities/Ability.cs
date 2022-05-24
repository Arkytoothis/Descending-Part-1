using DarkTonic.MasterAudio;
using Descending.Characters;
using Descending.Core;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Descending.Abilities
{
    [System.Serializable]
    public class Ability
    {
        [SerializeField] private AbilityType _abilityType = AbilityType.None;
        [SerializeField] private string _key = "";
        [SerializeField] private bool _empty = true;

        public AbilityType AbilityType { get => _abilityType; }
        public bool Empty { get => _empty; set => _empty = value; }
        public string Key { get => _key; set => _key = value; }

        public AbilityDefinition Definition => Database.instance.Abilities.GetAbility(_key);

        public Ability()
        {
            _abilityType = AbilityType.None;
            _key = "";
            _empty = true;
        }

        public Ability(Ability ability)
        {
            _abilityType = ability.AbilityType;
            _key = ability.Key;

            if (ability.AbilityType == AbilityType.None)
            {
                _empty = true;
            }
            else
            {
                _empty = false;
            }
        }

        public Ability(AbilityDefinition definition)
        {
            _empty = false;
            _abilityType = definition.Details.AbilityType;
            _key = definition.Details.Key;
        }

        public string DisplayName()
        {
            return Definition.Details.Name;
        }

        public string GetTooltipText()
        {
            StringBuilder sb = new StringBuilder();
            AbilityDefinition definition = Database.instance.Abilities.GetAbility(_key);

            sb.Append(definition.Details.GetTooltipText());

            if (definition.Effects != null)
            {
                sb.Append(definition.Effects.GetTooltipText());
            }

            return sb.ToString();
        }

        public bool Use(GameEntity user)
        {
            bool success = false;
            AbilityDefinition definition = Database.instance.Abilities.GetAbility(_key);
            user.Damage(definition.Details.ResourceAttribute.Key, definition.Details.ResourceAmount, null);
            
            if (definition.Effects != null)
            {
                success = false;

                // if (definition.Details.SoundKey != "")
                // {
                //     MasterAudio.PlaySound3DAtTransform(definition.Details.SoundKey, user.transform);
                // }
                
                for (int i = 0; i < definition.Effects.Data.Count; i++)
                {
                    definition.Effects.Data[i].Process(user, new List<GameEntity>());
                }
            }

            return success;
        }
    }
}