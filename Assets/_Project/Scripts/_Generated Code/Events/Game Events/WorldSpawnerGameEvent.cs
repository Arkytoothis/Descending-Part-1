using Descending.World;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	[CreateAssetMenu(
	    fileName = "WorldSpawnerGameEvent.asset",
	    menuName = SOArchitecture_Utility.GAME_EVENT + "WorldSpawner Event",
	    order = 120)]
	public sealed class WorldSpawnerGameEvent : GameEventBase<WorldSpawner>
	{
	}
}