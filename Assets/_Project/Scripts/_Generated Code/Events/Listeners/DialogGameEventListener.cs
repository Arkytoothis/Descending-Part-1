using Descending.World;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[AddComponentMenu(SOArchitecture_Utility.EVENT_LISTENER_SUBMENU + "Dialog")]
	public sealed class DialogGameEventListener : BaseGameEventListener<Dialog, DialogGameEvent, DialogUnityEvent>
	{
	}
}