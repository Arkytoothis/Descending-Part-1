using Descending.Characters;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[AddComponentMenu(SOArchitecture_Utility.EVENT_LISTENER_SUBMENU + "Hero")]
	public sealed class HeroGameEventListener : BaseGameEventListener<Hero, HeroGameEvent, HeroUnityEvent>
	{
	}
}