using Descending.World;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[AddComponentMenu(SOArchitecture_Utility.EVENT_LISTENER_SUBMENU + "WorldSpawner")]
	public sealed class WorldSpawnerGameEventListener : BaseGameEventListener<WorldSpawner, WorldSpawnerGameEvent, WorldSpawnerUnityEvent>
	{
	}
}