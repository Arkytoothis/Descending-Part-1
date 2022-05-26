using Descending.Characters;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[AddComponentMenu(SOArchitecture_Utility.EVENT_LISTENER_SUBMENU + "GameEntity")]
	public sealed class GameEntityGameEventListener : BaseGameEventListener<GameEntity, GameEntityGameEvent, GameEntityUnityEvent>
	{
	}
}