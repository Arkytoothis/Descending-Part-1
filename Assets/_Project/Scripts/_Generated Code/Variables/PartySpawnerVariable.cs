using Descending.Party;
using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public class PartySpawnerEvent : UnityEvent<PartySpawner> { }

	[CreateAssetMenu(
	    fileName = "PartySpawnerVariable.asset",
	    menuName = SOArchitecture_Utility.VARIABLE_SUBMENU + "PartySpawner Event",
	    order = 120)]
	public class PartySpawnerVariable : BaseVariable<PartySpawner, PartySpawnerEvent>
	{
	}
}