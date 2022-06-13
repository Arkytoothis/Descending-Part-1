using Descending.Combat;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[AddComponentMenu(SOArchitecture_Utility.EVENT_LISTENER_SUBMENU + "InitiativeDataList")]
	public sealed class InitiativeDataListGameEventListener : BaseGameEventListener<InitiativeDataList, InitiativeDataListGameEvent, InitiativeDataListUnityEvent>
	{
	}
}