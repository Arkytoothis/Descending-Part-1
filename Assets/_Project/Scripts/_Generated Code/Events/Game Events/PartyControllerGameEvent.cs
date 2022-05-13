using Descending.Party;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	[CreateAssetMenu(
	    fileName = "PartyControllerGameEvent.asset",
	    menuName = SOArchitecture_Utility.GAME_EVENT + "PartyController Event",
	    order = 120)]
	public sealed class PartyControllerGameEvent : GameEventBase<PartyController>
	{
	}
}