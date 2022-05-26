using Descending.Combat;
using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class CombatTileUnityEvent : UnityEvent<CombatTile>
	{
	}
}