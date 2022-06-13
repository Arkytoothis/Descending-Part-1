using Descending.Party;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	[CreateAssetMenu(
	    fileName = "PartySpawnerGameEvent.asset",
	    menuName = SOArchitecture_Utility.GAME_EVENT + "PartySpawner Event",
	    order = 120)]
	public sealed class PartySpawnerGameEvent : GameEventBase<PartySpawner>
	{
	}
}