using Descending.Enemies;
using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class EnemyUnityEvent : UnityEvent<Enemy>
	{
	}
}