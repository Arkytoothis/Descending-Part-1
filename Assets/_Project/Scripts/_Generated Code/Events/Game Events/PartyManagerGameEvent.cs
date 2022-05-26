using Descending.Scene_MainMenu;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	[CreateAssetMenu(
	    fileName = "PartyManagerGameEvent.asset",
	    menuName = SOArchitecture_Utility.GAME_EVENT + "PartyManager Event",
	    order = 120)]
	public sealed class PartyManagerGameEvent : GameEventBase<PartyManager>
	{
	}
}