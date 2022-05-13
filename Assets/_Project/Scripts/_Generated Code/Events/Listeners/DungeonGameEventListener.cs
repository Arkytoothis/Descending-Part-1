using UnityEngine;
using Descending.World;

namespace ScriptableObjectArchitecture
{
	[AddComponentMenu(SOArchitecture_Utility.EVENT_LISTENER_SUBMENU + "Dungeon")]
	public sealed class DungeonGameEventListener : BaseGameEventListener<Dungeon, DungeonGameEvent, DungeonUnityEvent>
	{
	}
}