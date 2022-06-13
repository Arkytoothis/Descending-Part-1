using Descending.Combat;
using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public class InitiativeDataListEvent : UnityEvent<InitiativeDataList> { }

	[CreateAssetMenu(
	    fileName = "InitiativeDataListVariable.asset",
	    menuName = SOArchitecture_Utility.VARIABLE_SUBMENU + "InitiativeDataList Event",
	    order = 120)]
	public class InitiativeDataListVariable : BaseVariable<InitiativeDataList, InitiativeDataListEvent>
	{
	}
}