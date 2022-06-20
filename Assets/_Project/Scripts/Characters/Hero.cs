using System;
using System.Collections;
using System.Collections.Generic;
using DarkTonic.MasterAudio;
using Descending.Attributes;
using Descending.Core;
using Descending.Equipment;
using Descending.Gui;
using ScriptableObjectArchitecture;
using UnityEngine;
using AttributesController = Descending.Attributes.AttributesController;
using AttributesSaveData = Descending.Attributes.AttributesSaveData;
using Random = UnityEngine.Random;

namespace Descending.Characters
{
    public class Hero : GameEntity
    {
        [SerializeField] private RuntimeAnimatorController _portraitController = null;
        
        [SerializeField] private HeroData _heroData = null;
        [SerializeField] private AttributesController _attributes = null;
        [SerializeField] private SkillsController _skills = null;
        [SerializeField] private InventoryController _inventory = null;
        [SerializeField] private AbilityController _abilities = null;
        
        [SerializeField] private Transform _portraitMount = null;
        [SerializeField] private Transform _hitEffectTransform = null;
        
        [SerializeField] private IntEvent onSyncHero = null;
        
        private GameObject _portraitModel = null;
        private PortraitMount _portrait = null;
        private BodyRenderer _portraitRenderer = null;
        
        public HeroData HeroData => _heroData;
        public AttributesController Attributes => _attributes;
        public SkillsController Skills => _skills;
        public InventoryController Inventory => _inventory;
        public AbilityController Abilities => _abilities;
        public GameObject PortraitModel => _portraitModel;
        public PortraitMount Portrait => _portrait;
        public BodyRenderer PortraitRenderer => _portraitRenderer;
        public Transform HitEffectTransform => _hitEffectTransform;

        private void Awake()
        {
        }

        private void Update()
        {
            //_worldAnimator.SetFloat("Blend", _rigidbody.velocity.magnitude);
        }

        public void Setup(Genders gender, RaceDefinition race, ProfessionDefinition profession, int listIndex)
        {
            _portraitModel = HeroBuilder.SpawnPortraitPrefab(gender, race, _portraitMount);

            var children = _portraitModel.GetComponentsInChildren<Transform>(includeInactive: true);
            foreach (var child in children)
            {
                child.gameObject.layer = LayerMask.NameToLayer("PortraitLight");
            }

            _portraitRenderer = _portraitModel.GetComponent<BodyRenderer>();
            _portraitRenderer.SetupBody(gender, race, profession);
            Animator portraitAnimator = _portraitModel.GetComponent<Animator>();
            portraitAnimator.runtimeAnimatorController = _portraitController;

            _heroData.Setup(gender, race, profession, _portraitRenderer, listIndex);
            _attributes.Setup(race, profession);
            _skills.Setup(_attributes, race, profession);
            _inventory.Setup(_portraitRenderer, gender, race, profession);
            _abilities.Setup(_heroData.Name, race, profession, _skills);
        }

        public void Load(HeroSaveData saveData)
        {
            RaceDefinition race = Database.instance.Races.GetRace(saveData.HeroData.RaceKey);
            ProfessionDefinition profession = Database.instance.Profession.GetProfession(saveData.HeroData.ProfessionKey);

            _portraitModel = HeroBuilder.SpawnPortraitPrefab(saveData.HeroData.Gender, race, _portraitMount);

            var children = _portraitModel.GetComponentsInChildren<Transform>(includeInactive: true);
            foreach (var child in children)
            {
                child.gameObject.layer = LayerMask.NameToLayer("PortraitLight");
            }

            _portraitRenderer = _portraitModel.GetComponent<BodyRenderer>();
            _portraitRenderer.LoadBody(saveData);
            Animator portraitAnimator = _portraitModel.GetComponent<Animator>();
            portraitAnimator.runtimeAnimatorController = _portraitController;

            _heroData.LoadData(saveData.HeroData, _portraitRenderer);
            _attributes.LoadData(saveData.AttributeData);
            _skills.LoadData(saveData.SkillData);
            _inventory.LoadData(_portraitRenderer, saveData.HeroData.Gender, saveData.InventoryData);
            _abilities.Setup(saveData.HeroData.Name, race, profession, _skills);
        }

        public void SetPortrait(PortraitMount portrait)
        {
            _portrait = portrait;
        }
        
        public override string GetName()
        {
            return _heroData.Name.FullName;
        }

        public override void Damage(string attribute, int amount, DamageTypeDefinition damageType)
        {
            if (IsAlive() == false) return;
            
            _attributes.Vitals["Life"].Damage(amount);
            
            if (_attributes.Vitals["Life"].Current <= 0)
            {
                Death();
            }
            else
            {
                string sound = _heroData.RaceDefinition.GetWoundSound(_heroData.Gender);
                MasterAudio.PlaySound3DAtTransform(sound, transform, .3f, 1f);
            }
            
            SyncData();
        }

        public override void UseActions(int amount)
        {
            _attributes.Vitals["Actions"].Damage(amount);
            SyncData();
        }

        public override void Restore(string attribute, int amount)
        {
            _attributes.Vitals["Life"].Restore(amount);
            SyncData();
        }

        public override void Death()
        {
            //_worldAnimator.SetTrigger("isDead");
            //_pathfinder.DisablePathing();
            //_behaviorController.SetBehaviorActive(false);
        }

        public override bool IsAlive()
        {
            return true;
        }

        public override void UseItem(Item item)
        {
            
        }

        public override void UseAccessory(int index)
        {
            
        }
        
        public override int RollDamage()
        {
            int min = _inventory.GetEquippedItem(EquipmentSlot.Right_Hand).GetWeaponData().MinDamage;
            int max = _inventory.GetEquippedItem(EquipmentSlot.Right_Hand).GetWeaponData().MaxDamage;

            return Random.Range(min, max + 1);
        }

        public override void MeleeAttack()
        {
            //_worldAnimator.SetTrigger("Attack");
            
            string swingSound = _inventory.GetEquippedWeapon().ItemDefinition.GetMissSound();
            MasterAudio.PlaySound3DAtTransform(swingSound, transform, .15f, 1f);
        }

        public override void SetListIndex(int index)
        {
            _listIndex = index;
        }

        public override void SetInitiativeIndex(int index)
        {
            _initiativeIndex = index;
        }

        public void AddExperience(int experience)
        {
            experience += (int)(experience * _heroData.RaceDefinition.ExpModifier);
            _heroData.AddExperience(experience);
        }

        private void SyncData()
        {
            onSyncHero.Invoke(_heroData.ListIndex);
        }
    }

    [System.Serializable]
    public class HeroSaveData
    {
        [SerializeField] private HeroDataSaveData _heroSaveData = null;
        [SerializeField] private AttributesSaveData _attributesSaveData = null;
        [SerializeField] private SkillsSaveData _skillsSaveData = null;
        [SerializeField] private InventorySaveData _inventorySaveData = null;

        public HeroDataSaveData HeroData => _heroSaveData;
        public AttributesSaveData AttributeData => _attributesSaveData;
        public SkillsSaveData SkillData => _skillsSaveData;
        public InventorySaveData InventoryData => _inventorySaveData;

        public HeroSaveData(Hero hero)
        {
            _heroSaveData = new HeroDataSaveData(hero);
            _attributesSaveData = new AttributesSaveData(hero);
            _skillsSaveData = new SkillsSaveData(hero);
            _inventorySaveData = new InventorySaveData(hero);
        }
    }
}
