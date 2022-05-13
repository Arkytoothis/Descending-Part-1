using Descending.Core;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Descending.Attributes
{
    [CreateAssetMenu(fileName = "Skill Definition", menuName = "Descending/Definition/Skill Definition")]
    public class SkillDefinition : ScriptableObject
    {
        [HorizontalGroup("Split", 150)]

        [SerializeField, HideLabel, PreviewField(78), BoxGroup("Split/Icon")]
        private Sprite _icon = null;

        [SerializeField] private string _name = "";
        [SerializeField] private string _key = "";

        [SerializeField, BoxGroup("Split/Details")]
        private SkillCategory _skillCategory = SkillCategory.None;
        
        //[SerializeField] private SkillAbilityUnlockDictionary _abilityUnlocks = null;
        
        public string Name => _name;
        public string Key => _key;
        public Sprite Icon { get => _icon; }
        public SkillCategory SkillCategory { get => _skillCategory; }
        //public SkillAbilityUnlockDictionary AbilityUnlocks => _abilityUnlocks;
    }
}