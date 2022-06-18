using Descending.Enemies;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[AddComponentMenu(SOArchitecture_Utility.EVENT_LISTENER_SUBMENU + "Enemy")]
	public sealed class EnemyGameEventListener : BaseGameEventListener<Enemy, EnemyGameEvent, EnemyUnityEvent>
	{
	}
}