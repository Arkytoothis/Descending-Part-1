using System;
using System.Collections;
using System.Collections.Generic;
using ScriptableObjectArchitecture;
using UnityEngine;

namespace Descending.Dungeons
{
    public class CharacterSpawnPoint : MonoBehaviour
    {
        [SerializeField] private GameObjectEvent onRegisterSpawnPoint = null;

        private void Awake()
        {
            onRegisterSpawnPoint.Invoke(gameObject);
        }
    }
}
