using Descending.Combat;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	[CreateAssetMenu(
	    fileName = "CombatTileGameEvent.asset",
	    menuName = SOArchitecture_Utility.GAME_EVENT + "CombatTile Event",
	    order = 120)]
	public sealed class CombatTileGameEvent : GameEventBase<CombatTile>
	{
	}
}