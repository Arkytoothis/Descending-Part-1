using UnityEngine;
using Descending.World;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	[CreateAssetMenu(
	    fileName = "TreasureGameEvent.asset",
	    menuName = SOArchitecture_Utility.GAME_EVENT + "Treasure Event",
	    order = 120)]
	public sealed class TreasureGameEvent : GameEventBase<TreasureChest>
	{
	}
}