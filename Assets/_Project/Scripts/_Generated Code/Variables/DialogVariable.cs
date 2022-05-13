using Descending.World;
using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public class DialogEvent : UnityEvent<Dialog> { }

	[CreateAssetMenu(
	    fileName = "DialogVariable.asset",
	    menuName = SOArchitecture_Utility.VARIABLE_SUBMENU + "Dialog Event",
	    order = 120)]
	public class DialogVariable : BaseVariable<Dialog, DialogEvent>
	{
	}
}