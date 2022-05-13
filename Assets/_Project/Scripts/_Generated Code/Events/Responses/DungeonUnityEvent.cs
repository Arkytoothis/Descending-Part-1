using UnityEngine;
using UnityEngine.Events;
using Descending.World;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class DungeonUnityEvent : UnityEvent<Dungeon>
	{
	}
}