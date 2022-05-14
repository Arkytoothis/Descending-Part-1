using UnityEngine;
using Descending.World;

namespace ScriptableObjectArchitecture
{
	[AddComponentMenu(SOArchitecture_Utility.EVENT_LISTENER_SUBMENU + "Treasure")]
	public sealed class TreasureGameEventListener : BaseGameEventListener<TreasureChest, TreasureGameEvent, TreasureUnityEvent>
	{
	}
}