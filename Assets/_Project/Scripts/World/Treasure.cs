using System;
using System.Collections;
using System.Collections.Generic;
using Descending.Equipment;
using ScriptableObjectArchitecture;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Descending.World
{
    public class Treasure : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _prefabs = null;
        [SerializeField] private GameObject _model = null;
        [SerializeField] private Transform _modelParent = null;
        [SerializeField] private bool _setParent = true;
        [SerializeField] private int _level = 0;

        [SerializeField] private TreasureEvent onRegisterTreasure = null;
        [SerializeField] private TreasureEvent onRemoveTreasure = null;
        [SerializeField] private IntEvent onAddCoins = null;
        [SerializeField] private IntEvent onAddGems = null;
        [SerializeField] private IntEvent onAddSupplies = null;
        
        private bool _isActive = false;
        [SerializeField] private int _lockLevel = 0;
        [SerializeField] private int _hiddenLevel = 0;
        [SerializeField] private int _coins = 0;
        [SerializeField] private int _gems = 0;
        [SerializeField] private int _supplies = 0;
        [SerializeField] private List<ItemShort> _items = null;

        public int LockLevel => _lockLevel;
        public int HiddenLevel => _hiddenLevel;
        public int Coins => _coins;
        public int Gems => _gems;
        public int Supplies => _supplies;
        public List<ItemShort> Items => _items;
        public bool IsActive => _isActive;
        public bool SetParent => _setParent;
        public int Level => _level;

        private void Awake()
        {
            onRegisterTreasure.Invoke(this);
        }

        public void GenerateTreasure(int level)
        {
            _model = Instantiate(_prefabs[0], _modelParent);

            _level = level;
            if (_level < 1) _level = 1;
            
            _coins = Random.Range(1, 21) * _level;
            _gems = Random.Range(0, 1) * _level;
            _supplies = Random.Range(0, 6) * _level;
            _lockLevel = Random.Range(1, 4) * _level;
            _hiddenLevel = Random.Range(0, 4) * _level;
            _items = new List<ItemShort>();
            //SetActive(false);
        }

        public void Loot()
        {
            onAddCoins.Invoke(_coins);
            onAddGems.Invoke(_gems);
            onAddSupplies.Invoke(_supplies);
            Destroy(gameObject);
            onRemoveTreasure.Invoke(this);
        }

        public void SetActive(bool active)
        {
            _isActive = active;
            if(_model != null) _model.SetActive(active);
        }

        public void SetParentOnSpawn(bool setParent)
        {
            _setParent = setParent;
        }
    }
}
