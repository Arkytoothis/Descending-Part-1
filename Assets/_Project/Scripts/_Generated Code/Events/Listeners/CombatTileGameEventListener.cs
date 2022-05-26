using Descending.Combat;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[AddComponentMenu(SOArchitecture_Utility.EVENT_LISTENER_SUBMENU + "CombatTile")]
	public sealed class CombatTileGameEventListener : BaseGameEventListener<CombatTile, CombatTileGameEvent, CombatTileUnityEvent>
	{
	}
}