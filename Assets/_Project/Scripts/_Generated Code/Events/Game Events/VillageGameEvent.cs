using UnityEngine;
using Descending.World;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	[CreateAssetMenu(
	    fileName = "VillageGameEvent.asset",
	    menuName = SOArchitecture_Utility.GAME_EVENT + "Village Event",
	    order = 120)]
	public sealed class VillageGameEvent : GameEventBase<Village>
	{
	}
}