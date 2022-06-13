using Descending.Combat;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	[CreateAssetMenu(
	    fileName = "InitiativeDataListGameEvent.asset",
	    menuName = SOArchitecture_Utility.GAME_EVENT + "InitiativeDataList Event",
	    order = 120)]
	public sealed class InitiativeDataListGameEvent : GameEventBase<InitiativeDataList>
	{
	}
}