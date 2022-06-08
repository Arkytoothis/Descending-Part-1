using Descending.Core;
using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public class LookModesEvent : UnityEvent<LookModes> { }

	[CreateAssetMenu(
	    fileName = "LookModesVariable.asset",
	    menuName = SOArchitecture_Utility.VARIABLE_SUBMENU + "LookModes Event",
	    order = 120)]
	public class LookModesVariable : BaseVariable<LookModes, LookModesEvent>
	{
	}
}