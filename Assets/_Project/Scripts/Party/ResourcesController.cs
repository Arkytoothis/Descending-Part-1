using System.Collections;
using System.Collections.Generic;
using System.IO;
using Descending.Core;
using ScriptableObjectArchitecture;
using Sirenix.Serialization;
using UnityEngine;

namespace Descending.Party
{
    public class ResourcesController : MonoBehaviour
    {
        [SerializeField] private IntEvent onSyncCoins = null;
        [SerializeField] private IntEvent onSyncGems = null;
        [SerializeField] private IntEvent onSyncSupplies = null;
        
        [SerializeField] private int _coins = 0;
        [SerializeField] private int _gems = 0;
        [SerializeField] private int _supplies = 0;

        public void AddCoins(int amount)
        {
            _coins += amount;
            onSyncCoins.Invoke(_coins);
        }

        public void AddSupplies(int amount)
        {
            _supplies += amount;
            onSyncSupplies.Invoke(_supplies);
        }

        public void AddGems(int amount)
        {
            _gems += amount;
            onSyncGems.Invoke(_gems);
        }

        public void RemoveCoins(int amount)
        {
            _coins -= amount;
            onSyncCoins.Invoke(_coins);
        }

        public void RemoveSupplies(int amount)
        {
            _supplies -= amount;
            onSyncSupplies.Invoke(_supplies);
        }

        public void RemoveGems(int amount)
        {
            _gems -= amount;
            onSyncGems.Invoke(_gems);
        }

        public void OnNewDay(int day)
        {
            RemoveSupplies(4);   
        }

        public void Load(ResourceSaveData saveData)
        {
            _coins = saveData.Coins;
            _gems = saveData.Gems;
            _supplies = saveData.Supplies;
        }
        
        public void Save()
        {
            ResourceSaveData saveData = new ResourceSaveData(_coins, _gems, _supplies);
            byte[] bytes = SerializationUtility.SerializeValue(saveData, DataFormat.Binary);
            File.WriteAllBytes(Database.instance.ResourceDataFilePath, bytes);
        }
    }

    [System.Serializable]
    public class ResourceSaveData
    {
        [SerializeField] private int _coins = 0;
        [SerializeField] private int _gems = 0;
        [SerializeField] private int _supplies = 0;
        
        public int Coins => _coins;
        public int Gems => _gems;
        public int Supplies => _supplies;

        public ResourceSaveData(int coins, int gems, int supplies)
        {
            _coins = coins;
            _gems = gems;
            _supplies = supplies;
        }
    }
}
