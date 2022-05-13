using Descending.Core;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using DarkTonic.MasterAudio;
using UnityEngine;

namespace Descending.Equipment
{
    public enum WeaponType
    {
        Melee, Ranged, Magic, Number, None
    }

    [System.Serializable]
    public class WeaponData
    {
        [SerializeField] private bool _hasData = true;
        [SerializeField] private WeaponType _weaponType = WeaponType.None;
        [SerializeField] private float _range = 0;
        [SerializeField] private float _delay = 0;
        [SerializeField] private float _knockbackStrength = 0;
        [SerializeField] private DamageTypeDefinition _damageType = null;
        [SerializeField] private int _minDamage = 0;
        [SerializeField] private int _maxDamage = 0;
        [SerializeField] private AnimatorOverrideController _animatorOverride = null;

        [SoundGroupAttribute] public List<string> HitSounds;
        [SoundGroupAttribute] public List<string> MissSounds;
        
        public bool HasData { get => _hasData; }
        public WeaponType WeaponType { get => _weaponType; }
        public float Range { get => _range; }
        public float Delay { get => _delay; }
        public DamageTypeDefinition DamageType { get => _damageType; }
        public int MinDamage { get => _minDamage; }
        public int MaxDamage { get => _maxDamage; }
        public float KnockbackStrength { get => _knockbackStrength; }
        public AnimatorOverrideController AnimatorOverride => _animatorOverride;

        public WeaponData(WeaponData weaponData)
        {
            _hasData = weaponData._hasData;
            _delay = weaponData._delay;
            _range = weaponData._range;
            _weaponType = weaponData._weaponType;
            _animatorOverride = weaponData.AnimatorOverride;
            _damageType = weaponData._damageType;
            _minDamage = weaponData._minDamage;
            _maxDamage = weaponData._maxDamage;
            _damageType = weaponData._damageType;
        }

        public string GetTooltipText()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Delay: ");
            sb.Append(_delay);
            sb.Append("\n");

            sb.Append("Range: ");
            sb.Append(_range);
            sb.Append("\n");

            sb.Append("Weapon Type: ");
            sb.Append(_weaponType);
            sb.Append("\n");

            sb.Append(_minDamage);
            sb.Append("-");
            sb.Append(_maxDamage);
            sb.Append(" ");

            if (_damageType != null)
            {
                sb.Append(_damageType.Name);
                sb.Append(" damage\n");
            }

            return sb.ToString();
        }
    }
}