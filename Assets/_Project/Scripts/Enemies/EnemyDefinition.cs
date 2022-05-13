using System.Collections;
using System.Collections.Generic;
using DarkTonic.MasterAudio;
using Descending.Attributes;
using Descending.Core;
using Descending.Enemies;
using UnityEngine;

namespace Descending
{
    [CreateAssetMenu(fileName = "Enemy Definition", menuName = "Descending/Definition/Enemy Definition")]
    public class EnemyDefinition : ScriptableObject
    {
        public string Name = "Unnamed Enemy";
        public string Key = "";
        public int ExpValue = 0;

        public GameObject Prefab = null;
        public Sprite Icon = null;
        public EnemyGroups Group = EnemyGroups.None;
        public ParticleSystem HitEffect = null;

        public StartingVitalDictionary StartingVitals = null;
        public StartingStatisticDictionary StartingStatistic = null;
        public StartingSkillDictionary StartingSkills = null;
        public List<Resistance> Resistances = null;
        public List<EnemyDropData> ItemDrops = null;
        
        [SoundGroupAttribute] public List<string> AttackSounds;
        [SoundGroupAttribute] public List<string> HitSounds;
        [SoundGroupAttribute] public List<string> WoundSounds;
        
        public string GetAttackSound()
        {
            return AttackSounds[Random.Range(0, AttackSounds.Count)];
        }
        
        public string GetHitSound()
        {
            return HitSounds[Random.Range(0, HitSounds.Count)];
        }
        
        public string GetWoundSound()
        {
            return WoundSounds[Random.Range(0, WoundSounds.Count)];
        }
    }
}