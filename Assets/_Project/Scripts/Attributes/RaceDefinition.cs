using Descending.Core;
using System.Collections;
using System.Collections.Generic;
using DarkTonic.MasterAudio;
using UnityEngine;
using UnityEngine.Serialization;

namespace Descending.Attributes
{
    [CreateAssetMenu(fileName = "Race Definition", menuName = "Descending/Definition/Race Definition")]
	public class RaceDefinition : ScriptableObject
	{
        [SerializeField] private bool _unlocked = false;
        [SerializeField] private GameObject _prefabMale = null;
        [SerializeField] private GameObject _prefabFemale = null;
        [SerializeField] private string _key = "";
        [SerializeField] private string _name = "";
        [SerializeField] private Sprite _icon = null;
        [SerializeField] private ParticleSystem _hitEffect = null;
        
        [SerializeField] private int _earIndex = 0;
        [SerializeField] private bool _hairAllowed = true;
        [SerializeField] private bool _eyebrowsAllowed = true;
        [SerializeField] private bool _beardAllowed = true;
        [SerializeField] private int _beardChance = 75;
        [SerializeField] private List<Color> _skinColors = null;
        [SerializeField] private List<Color> _eyeColors = null;
        [SerializeField] private List<Color> _hairColors = null;
        [SerializeField] private List<Color> _tattooColors = null;
        [SerializeField] private List<Color> _scarColors = null;
        [SerializeField] private List<Color> _stubbleColors = null;
        
        [SerializeField] private float _expModifier = 1f;
        
        [SerializeField] private StartingCharacteristicDictionary _startingCharacteristics = null;
        [SerializeField] private StartingVitalDictionary _startingVitals = null;
        [SerializeField] private StartingStatisticDictionary _startingStatistics = null;
        [SerializeField] private StartingSkillDictionary _startingSkills = null;
        [SerializeField] private List<Resistance> _resistances = null;

        [SoundGroupAttribute] public List<string> AttackSoundsMale;
        [SoundGroupAttribute] public List<string> AttackSoundsFemale;
        [SoundGroupAttribute] public List<string> HitSoundsMale;
        [SoundGroupAttribute] public List<string> HitSoundsFemale;
        [SoundGroupAttribute] public List<string> WoundSoundsMale;
        [SoundGroupAttribute] public List<string> WoundSoundsFemale;
        public StartingCharacteristicDictionary StartingCharacteristics => _startingCharacteristics;
        public StartingVitalDictionary StartingVitals => _startingVitals;
        public StartingStatisticDictionary StartingStatistics => _startingStatistics;
        public StartingSkillDictionary StartingSkills => _startingSkills;
        public List<Resistance> Resistances => _resistances;
        public bool Unlocked { get => _unlocked; set => _unlocked = value; }
        public int BeardChance => _beardChance;
        public GameObject PrefabMale => _prefabMale;
        public GameObject PrefabFemale => _prefabFemale;
        public ParticleSystem HitEffect => _hitEffect;

        public string Key
        {
            get => _key;
            set => _key = value;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public int EarIndex { get => _earIndex; }
        public bool HairAllowed { get => _hairAllowed; }
        public bool EyebrowsAllowed { get => _eyebrowsAllowed; }
        public bool BeardAllowed { get => _beardAllowed; }

        public List<Color> SkinColors { get => _skinColors; }
        public List<Color> EyeColors { get => _eyeColors; }
        public List<Color> ScarColors { get => _scarColors; }
        public List<Color> StubbleColors { get => _stubbleColors; }
        public List<Color> HairColors { get => _hairColors; }
        public List<Color> TattooColors { get => _tattooColors; }
        public Sprite Icon { get => _icon; }
        public float ExpModifier => _expModifier;

        public string GetAttackSound(Genders gender)
        {
            if(gender == Genders.Male)
                return AttackSoundsMale[Random.Range(0, AttackSoundsMale.Count)];
            else
                return AttackSoundsFemale[Random.Range(0, AttackSoundsFemale.Count)];
        }

        public string GetWoundSound(Genders gender)
        {
            if(gender == Genders.Male)
                return AttackSoundsMale[Random.Range(0, AttackSoundsMale.Count)];
            else
                return AttackSoundsFemale[Random.Range(0, AttackSoundsFemale.Count)];
        }
    }
}