using UnityEngine;
using UnityEngine.Events;
using Descending.World;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public class TreasureEvent : UnityEvent<Treasure> { }

	[CreateAssetMenu(
	    fileName = "TreasureVariable.asset",
	    menuName = SOArchitecture_Utility.VARIABLE_SUBMENU + "Treasure Event",
	    order = 120)]
	public class TreasureVariable : BaseVariable<Treasure, TreasureEvent>
	{
	}
}