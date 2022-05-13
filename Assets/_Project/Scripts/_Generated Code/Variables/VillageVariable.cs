using UnityEngine;
using UnityEngine.Events;
using Descending.World;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public class VillageEvent : UnityEvent<Village> { }

	[CreateAssetMenu(
	    fileName = "VillageVariable.asset",
	    menuName = SOArchitecture_Utility.VARIABLE_SUBMENU + "Village Event",
	    order = 120)]
	public class VillageVariable : BaseVariable<Village, VillageEvent>
	{
	}
}