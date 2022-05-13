using System;
using System.Collections;
using System.Collections.Generic;
using DarkTonic.MasterAudio;
using Descending.Attributes;
using Descending.Core;
using Descending.Enemies;
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
        [SerializeField] private RuntimeAnimatorController _worldController = null;
        [SerializeField] private RuntimeAnimatorController _portraitController = null;
        
        [SerializeField] private HeroData _heroData = null;
        [SerializeField] private AttributesController _attributes = null;
        [SerializeField] private SkillsController _skills = null;
        [SerializeField] private InventoryController _inventory = null;
        [SerializeField] private Transform _worldMount = null;
        [SerializeField] private Transform _portraitMount = null;
        //[SerializeField] private BehaviorController _behaviorController = null;
        [SerializeField] private HeroPathfinder _pathfinder = null;
        [SerializeField] private VitalBar _lifeBar = null;
        [SerializeField] private Transform _hitEffectTransform = null;
        
        [SerializeField] private IntEvent onSyncHero = null;
        
        [SerializeField]private GameObject _worldModel = null;
        [SerializeField]private GameObject _portraitModel = null;
        private PortraitMount _portrait = null;
        private Rigidbody _rigidbody = null;
        private Animator _worldAnimator = null;
        private BodyRenderer _worldRenderer = null;
        private BodyRenderer _portraitRenderer = null;
        private AnimationEvents _animationEvents = null;
        
        //public BehaviorController BehaviorController => _behaviorController;
        public HeroData HeroData => _heroData;
        public AttributesController Attributes => _attributes;
        public SkillsController Skills => _skills;
        public InventoryController Inventory => _inventory;
        public GameObject WorldModel => _worldModel;
        public GameObject PortraitModel => _portraitModel;
        public PortraitMount Portrait => _portrait;
        public HeroPathfinder Pathfinder => _pathfinder;
        public BodyRenderer WorldRenderer => _worldRenderer;
        public BodyRenderer PortraitRenderer => _portraitRenderer;
        public VitalBar LifeBar => _lifeBar;
        public Transform HitEffectTransform => _hitEffectTransform;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            _worldAnimator.SetFloat("Blend", _rigidbody.velocity.magnitude);
        }

        public void Setup(Genders gender, RaceDefinition race, ProfessionDefinition profession, bool equipWeapons, int listIndex, bool enabledInfoBar)
        {
            _worldModel = HeroBuilder.SpawnWorldPrefab(gender, race, _worldMount);
            _worldRenderer = _worldModel.GetComponent<BodyRenderer>();
            _worldRenderer.SetupBody(gender, race, profession);
            _worldAnimator = _worldModel.GetComponent<Animator>();
            _worldAnimator.runtimeAnimatorController = _worldController;

            _animationEvents = _worldModel.GetComponentInChildren<AnimationEvents>();
            _animationEvents.Setup(this);
            
            _portraitModel = HeroBuilder.SpawnPortraitPrefab(gender, race, _portraitMount);
            
            var children = _portraitModel.GetComponentsInChildren<Transform>(includeInactive: true);
            foreach (var child in children)
            {
                child.gameObject.layer = LayerMask.NameToLayer("PortraitLight");
            }
            
            _portraitRenderer = _portraitModel.GetComponent<BodyRenderer>();
            _portraitRenderer.SetupBody(gender, race, profession, _worldRenderer);
            Animator portraitAnimator = _portraitModel.GetComponent<Animator>();
            portraitAnimator.runtimeAnimatorController = _portraitController;
            
            _heroData.Setup(gender, race, profession, _worldModel.GetComponent<BodyRenderer>(), listIndex);
            _attributes.Setup(race, profession);
            _skills.Setup(_attributes, race, profession);
            _inventory.Setup(_worldRenderer, _portraitRenderer, gender, race, profession, equipWeapons);

            if (enabledInfoBar == true)
            {
                _lifeBar.SetValues(_attributes.GetVital("Life").Current, _attributes.GetVital("Life").Maximum, false);
                _lifeBar.Show();
            }
            else
            {
                _lifeBar.Hide();
            }
        }

        public void Load(HeroSaveData saveData, bool equipWeapons)
        {
            RaceDefinition race = Database.instance.Races.GetRace(saveData.HeroData.RaceKey);
            ProfessionDefinition profession = Database.instance.Profession.GetProfession(saveData.HeroData.ProfessionKey);
            _worldModel = HeroBuilder.SpawnWorldPrefab(saveData.HeroData.Gender, race, _worldMount);
            _worldRenderer = _worldModel.GetComponent<BodyRenderer>();
            _worldRenderer.LoadBody(saveData);
            _worldAnimator = _worldModel.GetComponent<Animator>();
            _worldAnimator.runtimeAnimatorController = _worldController;

            _animationEvents = _worldModel.GetComponentInChildren<AnimationEvents>();
            _animationEvents.Setup(this);
            
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
            
            _heroData.LoadData(saveData.HeroData, _worldRenderer);
            _attributes.LoadData(saveData.AttributeData);
            _skills.LoadData(saveData.SkillData);
            _inventory.LoadData(_worldRenderer, _portraitRenderer, saveData.HeroData.Gender, saveData.InventoryData, true);
            _lifeBar.SetValues(_attributes.GetVital("Life").Current, _attributes.GetVital("Life").Maximum, false);
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
            _lifeBar.SetValues(_attributes.GetVital("Life").Current, _attributes.GetVital("Life").Maximum, false);
            
            if (_attributes.Vitals["Life"].Current <= 0)
            {
                Death();
                _lifeBar.gameObject.SetActive(false);
            }
            else
            {
                string sound = _heroData.RaceDefinition.GetWoundSound(_heroData.Gender);
                MasterAudio.PlaySound3DAtTransform(sound, transform, .3f, 1f);
            }
            
            SyncData();
        }

        public override void Restore(string attribute, int amount)
        {
            _attributes.Vitals["Life"].Restore(amount);
            _lifeBar.SetValues(_attributes.GetVital("Life").Current, _attributes.GetVital("Life").Maximum, false);
            SyncData();
        }

        public override void Death()
        {
            _worldAnimator.SetTrigger("isDead");
            _pathfinder.DisablePathing();
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
            _worldAnimator.SetTrigger("Attack");

            // if (Random.Range(0, 100) < 50)
            // {
            //     string attackSound = _heroData.RaceDefinition.GetAttackSound(_heroData.Gender);
            //     MasterAudio.PlaySound3DAtTransform(attackSound, transform, .3f, 1f);
            // }
            
            string swingSound = _inventory.GetEquippedWeapon().ItemDefinition.GetMissSound();
            MasterAudio.PlaySound3DAtTransform(swingSound, transform, .15f, 1f);
        }

        public void AddExperience(int experience)
        {
            experience += (int)(experience * _heroData.RaceDefinition.ExpModifier);
            _heroData.AddExperience(experience);
            SyncData();
        }

        private void SyncData()
        {
            onSyncHero.Invoke(_heroData.ListIndex);
        }

        public void SetTarget(Enemy enemyTarget)
        {
            _animationEvents.SetTarget(enemyTarget);
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
