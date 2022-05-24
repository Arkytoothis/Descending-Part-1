using DarkTonic.MasterAudio;
using Descending.Characters;
using Descending.Core;
using System.Collections.Generic;
using System.Text;
using Descending.Attributes;
using UnityEngine;

namespace Descending.Abilities
{
    [System.Serializable]
    public class RestoreEffect : AbilityEffect
    {
        [SerializeField] private AttributeDefinition _attribute = null;
        [SerializeField] private int _minimumValue = 0;
        [SerializeField] private int _maximumValue = 0;

        [SerializeField] private GameObject _casterEffectPrefab = null;
        [SerializeField] private GameObject _targetEffectPrefab = null;
        
        public AttributeDefinition Attribute { get => _attribute; }
        public int MinimumValue { get => _minimumValue; }
        public int MaximumValue { get => _maximumValue; }

        public override string GetTooltipText()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Restores ").Append(_minimumValue).Append(" - ").Append(_maximumValue).Append(" ").Append(_attribute).Append("\n");

            return sb.ToString();
        }

        public override void Process(GameEntity user, List<GameEntity> targets)
        {
            //Debug.Log("Processing RestoreEffect");
            if (_affects == AbilityEffectAffects.User)
            {
                int amount = Random.Range(_minimumValue, _maximumValue + 1);
                user.Restore(_attribute.Key, amount);
                //Debug.Log("Restoring " + amount + " " + _attribute + " to " + user.name);

                if (_casterEffectPrefab != null)
                {
                    //PoolBoss.SpawnWithFollow(_casterEffectPrefab.transform, user.transform.position, _casterEffectPrefab.transform.rotation, user.transform);
                }
            }
            else if (_affects == AbilityEffectAffects.Target)
            {
                foreach (GameEntity entity in targets)
                {
                    int amount = Random.Range(_minimumValue, _maximumValue + 1);
                    entity.Restore(_attribute.Key, amount);
                    //Debug.Log("Restoring " + amount + " " + _attribute + " to " + entity.name);
                    
                    if (_targetEffectPrefab != null)
                    {
                        //PoolBoss.SpawnWithFollow(_targetEffectPrefab.transform, user.transform.position, _targetEffectPrefab.transform.rotation, entity.transform);
                    }
                }
            }
        }
    }
}