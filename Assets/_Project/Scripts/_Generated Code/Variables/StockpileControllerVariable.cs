using Descending.Party;
using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public class StockpileControllerEvent : UnityEvent<StockpileController> { }

	[CreateAssetMenu(
	    fileName = "StockpileControllerVariable.asset",
	    menuName = SOArchitecture_Utility.VARIABLE_SUBMENU + "StockpileController Event",
	    order = 120)]
	public class StockpileControllerVariable : BaseVariable<StockpileController, StockpileControllerEvent>
	{
	}
}