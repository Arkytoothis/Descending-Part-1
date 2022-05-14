using System.Collections;
using System.Collections.Generic;
using Descending.Equipment;
using ScriptableObjectArchitecture;
using UnityEngine;

namespace Descending.World
{
    public class TreasureChest : Feature
    {
        [SerializeField] private int _level = 0;
        
        private bool _isActive = false;
        [SerializeField] private int _lockLevel = 0;
        [SerializeField] private int _hiddenLevel = 0;
        [SerializeField] private int _coins = 0;
        [SerializeField] private int _gems = 0;
        [SerializeField] private int _materials = 0;
        [SerializeField] private int _supplies = 0;
        [SerializeField] private List<ItemShort> _items = null;
        
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
        public int LockLevel => _lockLevel;
        public int HiddenLevel => _hiddenLevel;

        public List<ItemShort> Items => _items;

        public override void Interact()
        {
            if (_interacting == false)
            {
                //Debug.Log("Interacting with " + Definition.Name);
                GenerateTreasure();
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
            
            _coins = Random.Range(1, 21) * _level;
            _gems = Random.Range(0, 1) * _level;
            _materials = Random.Range(0, 11) * _level;
            _supplies = Random.Range(0, 6) * _level;
            _lockLevel = Random.Range(1, 4) * _level;
            _hiddenLevel = Random.Range(0, 4) * _level;
            _items = new List<ItemShort>();
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
