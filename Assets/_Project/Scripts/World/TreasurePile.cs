using System;
using System.Collections;
using System.Collections.Generic;
using Descending.Equipment;
using ScriptableObjectArchitecture;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Descending.World
{
    public class TreasurePile : Feature
    {
        [SerializeField] private int _level = 0;
        
        private bool _isActive = false;
        [SerializeField] private int _minCoins = 0;
        [SerializeField] private int _maxCoins = 0;
        [SerializeField] private int _minGems = 0;
        [SerializeField] private int _maxGems = 0;
        [SerializeField] private int _minMaterials = 0;
        [SerializeField] private int _maxMaterials = 0;
        [SerializeField] private int _minSupplies = 0;
        [SerializeField] private int _maxSupplies = 0;
        
        [SerializeField] private int _coins = 0;
        [SerializeField] private int _gems = 0;
        [SerializeField] private int _materials = 0;
        [SerializeField] private int _supplies = 0;
        
        [SerializeField] private FeatureEvent onInteractWithFeature = null;
        [SerializeField] private IntEvent onAddCoins = null;
        [SerializeField] private IntEvent onAddGems = null;
        [SerializeField] private IntEvent onAddMaterials = null;
        [SerializeField] private IntEvent onAddSupplies = null;

        public int Level => _level;
        public int Coins => _coins;
        public int Gems => _gems;
        public int Materials => _materials;
        public int Supplies => _supplies;

        private void Start()
        {
            GenerateTreasure();
        }

        public override void Interact()
        {
            if (_interacting == false)
            {
                //Debug.Log("Interacting with " + Definition.Name);
                _interacting = true;
                onInteractWithFeature.Invoke(this);
            }
        }

        public void EndInteraction()
        {
            _interacting = false;
        }
        
        public void GenerateTreasure()
        {
            if (_level == 0) _level = 1;
            
            _coins = Random.Range(_minCoins, _maxCoins + 1) * _level;
            _gems = Random.Range(_minGems, _maxGems + 1) * _level;
            _materials = Random.Range(_minMaterials, _maxMaterials + 1) * _level;
            _supplies = Random.Range(_minSupplies, _maxSupplies + 1) * _level;
        }

        public void Loot()
        {
            onAddCoins.Invoke(_coins);
            onAddGems.Invoke(_gems);
            onAddMaterials.Invoke(_materials);
            onAddSupplies.Invoke(_supplies);
            Destroy(gameObject);
        }
    }
}
