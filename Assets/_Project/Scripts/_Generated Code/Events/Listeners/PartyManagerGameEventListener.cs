using Descending.Scene_MainMenu;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[AddComponentMenu(SOArchitecture_Utility.EVENT_LISTENER_SUBMENU + "PartyManager")]
	public sealed class PartyManagerGameEventListener : BaseGameEventListener<PartyManager, PartyManagerGameEvent, PartyManagerUnityEvent>
	{
	}
}