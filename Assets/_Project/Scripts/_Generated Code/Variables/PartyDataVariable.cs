using Descending.Party;
using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public class PartyDataEvent : UnityEvent<PartyData> { }

	[CreateAssetMenu(
	    fileName = "PartyDataVariable.asset",
	    menuName = SOArchitecture_Utility.VARIABLE_SUBMENU + "PartyData Event",
	    order = 120)]
	public class PartyDataVariable : BaseVariable<PartyData, PartyDataEvent>
	{
	}
}