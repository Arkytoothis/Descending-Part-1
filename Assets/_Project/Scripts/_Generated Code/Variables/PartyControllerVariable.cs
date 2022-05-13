using Descending.Party;
using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public class PartyControllerEvent : UnityEvent<PartyController> { }

	[CreateAssetMenu(
	    fileName = "PartyControllerVariable.asset",
	    menuName = SOArchitecture_Utility.VARIABLE_SUBMENU + "PartyController Event",
	    order = 120)]
	public class PartyControllerVariable : BaseVariable<PartyController, PartyControllerEvent>
	{
	}
}