using Descending.Combat;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[AddComponentMenu(SOArchitecture_Utility.EVENT_LISTENER_SUBMENU + "CombatParameters")]
	public sealed class CombatParametersGameEventListener : BaseGameEventListener<CombatParameters, CombatParametersGameEvent, CombatParametersUnityEvent>
	{
	}
}