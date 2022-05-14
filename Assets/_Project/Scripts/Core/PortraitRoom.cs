using System;
using System.Collections;
using System.Collections.Generic;
using Descending.Core;
using Descending.Party;
using UnityEngine;

namespace Descending.Core
{
    public class PortraitRoom : MonoBehaviour
    {
        [SerializeField] private GameObject _portraitMountPrefab = null;
        [SerializeField] private Transform _portraitMountsParent = null;

        private List<PortraitMount> _portraits = null;
        private PartyData _partyData = null;
        
        public void Setup(PartyData partyData)
        {
            _portraits = new List<PortraitMount>();
            _partyData = partyData;
            
            for (int i = 0; i < partyData.Heroes.Count; i++)
            {
                GameObject clone = Instantiate(_portraitMountPrefab, _portraitMountsParent);
                //clone.transform.SetParent(_portraitMountsParent, false);
                clone.transform.localPosition = new Vector3(i * 10f, 0, 0);
                
                PortraitMount mount = clone.GetComponent<PortraitMount>();
                mount.Setup(_partyData.Heroes[i]);
                _portraits.Add(mount);
            }
        }

        // public void OnSyncParty(PartyData partyData)
        // {
        //     Debug.Log("Party Synced - Portrait Room");
        //     for (int i = 0; i < partyData.Heroes.Count; i++)
        //     {
        //         _portraits[i].SetModel(partyData.Heroes[i]);
        //     }
        // }
    }
}
