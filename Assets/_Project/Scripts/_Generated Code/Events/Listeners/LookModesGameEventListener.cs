using Descending.Core;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[AddComponentMenu(SOArchitecture_Utility.EVENT_LISTENER_SUBMENU + "LookModes")]
	public sealed class LookModesGameEventListener : BaseGameEventListener<LookModes, LookModesGameEvent, LookModesUnityEvent>
	{
	}
}