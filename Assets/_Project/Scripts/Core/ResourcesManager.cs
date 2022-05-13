using System.Collections;
using System.Collections.Generic;
using ScriptableObjectArchitecture;
using UnityEngine;

namespace Descending.Core
{
    public class ResourcesManager : MonoBehaviour
    {
        [SerializeField] private IntEvent onSyncCoins = null;
        [SerializeField] private IntEvent onSyncGems = null;
        [SerializeField] private IntEvent onSyncSouls = null;
        
        private int _coins = 0;
        private int _gems = 0;
        private int _souls = 0;

        public int Coins => _coins;
        public int Gems => _gems;
        public int Souls => _souls;

        public void Setup()
        {
            AddCoins(1000);  
            AddGems(10);
            AddSouls(0);
        }
        
        public void AddCoins(int amount)
        {
            _coins += amount;
            onSyncCoins.Invoke(_coins);
        }

        public void AddGems(int amount)
        {
            _gems += amount;
            onSyncGems.Invoke(_gems);
        }

        public void AddSouls(int amount)
        {
            _souls += amount;
            onSyncSouls.Invoke(_souls);
        }

        public void OnAddCoins(int amount)
        {
            AddCoins(amount);
        }

        public void OnAddGems(int amount)
        {
            AddGems(amount);
        }

        public void OnAddSouls(int amount)
        {
            AddSouls(amount);
        }
    }
}
