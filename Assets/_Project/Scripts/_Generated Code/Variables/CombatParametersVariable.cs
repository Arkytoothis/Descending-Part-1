using Descending.Combat;
using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public class CombatParametersEvent : UnityEvent<CombatParameters> { }

	[CreateAssetMenu(
	    fileName = "CombatParametersVariable.asset",
	    menuName = SOArchitecture_Utility.VARIABLE_SUBMENU + "CombatParameters Event",
	    order = 120)]
	public class CombatParametersVariable : BaseVariable<CombatParameters, CombatParametersEvent>
	{
	}
}