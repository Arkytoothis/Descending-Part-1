using Descending.Scene_MainMenu;
using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public class PartyManagerEvent : UnityEvent<PartyManager> { }

	[CreateAssetMenu(
	    fileName = "PartyManagerVariable.asset",
	    menuName = SOArchitecture_Utility.VARIABLE_SUBMENU + "PartyManager Event",
	    order = 120)]
	public class PartyManagerVariable : BaseVariable<PartyManager, PartyManagerEvent>
	{
	}
}