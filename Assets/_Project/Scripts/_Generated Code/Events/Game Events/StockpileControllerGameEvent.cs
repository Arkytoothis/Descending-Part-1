using Descending.Party;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	[CreateAssetMenu(
	    fileName = "StockpileControllerGameEvent.asset",
	    menuName = SOArchitecture_Utility.GAME_EVENT + "StockpileController Event",
	    order = 120)]
	public sealed class StockpileControllerGameEvent : GameEventBase<StockpileController>
	{
	}
}