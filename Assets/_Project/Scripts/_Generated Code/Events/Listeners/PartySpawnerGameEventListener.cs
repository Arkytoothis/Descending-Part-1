using Descending.Party;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[AddComponentMenu(SOArchitecture_Utility.EVENT_LISTENER_SUBMENU + "PartySpawner")]
	public sealed class PartySpawnerGameEventListener : BaseGameEventListener<PartySpawner, PartySpawnerGameEvent, PartySpawnerUnityEvent>
	{
	}
}