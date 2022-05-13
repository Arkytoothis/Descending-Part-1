using Descending.Party;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	[CreateAssetMenu(
	    fileName = "PartyDataGameEvent.asset",
	    menuName = SOArchitecture_Utility.GAME_EVENT + "PartyData Event",
	    order = 120)]
	public sealed class PartyDataGameEvent : GameEventBase<PartyData>
	{
	}
}