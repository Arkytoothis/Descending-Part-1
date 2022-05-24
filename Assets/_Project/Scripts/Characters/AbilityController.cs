using System.Collections;
using System.Collections.Generic;
using Descending.Abilities;
using Descending.Attributes;
using Descending.Core;
using UnityEngine;

namespace Descending.Characters
{
    public class AbilityController : MonoBehaviour
    {
        [SerializeField] private List<Ability> _memorizedPowers = null;
        [SerializeField] private List<Ability> _memorizedSpells = null;
        [SerializeField] private List<Ability> _traits = null;

        public List<Ability> MemorizedPowers => _memorizedPowers;
        public List<Ability> MemorizedSpells => _memorizedSpells;

        public void Setup(FantasyName heroName, RaceDefinition race, ProfessionDefinition profession, SkillsController skills)
        {
            FindStartingAbilities(heroName, race, profession, skills);
        }

        private void FindStartingAbilities(FantasyName heroName, RaceDefinition race, ProfessionDefinition profession, SkillsController skills)
        {
            foreach (var abilityKvp in Database.instance.Abilities.Abilities)
            {
                if (skills.ContainsSkills(abilityKvp.Value.Details.Skill) && skills.GetSkill(abilityKvp.Value.Details.Skill.Key).Current >= abilityKvp.Value.Details.MinimumSkill)
                {
                    if (abilityKvp.Value.Details.AbilityType == AbilityType.Power)
                    {
                        _memorizedPowers.Add(new Ability(abilityKvp.Value));
                    }
                    else if (abilityKvp.Value.Details.AbilityType == AbilityType.Spell)
                    {
                        _memorizedSpells.Add(new Ability(abilityKvp.Value));
                    }
                }
            }
        }
    }
}