using Descending.Party;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[AddComponentMenu(SOArchitecture_Utility.EVENT_LISTENER_SUBMENU + "PartyController")]
	public sealed class PartyControllerGameEventListener : BaseGameEventListener<PartyController, PartyControllerGameEvent, PartyControllerUnityEvent>
	{
	}
}