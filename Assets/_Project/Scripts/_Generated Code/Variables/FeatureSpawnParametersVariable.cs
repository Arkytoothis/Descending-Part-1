using Descending;
using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public class FeatureSpawnParametersEvent : UnityEvent<FeatureSpawnParameters> { }

	[CreateAssetMenu(
	    fileName = "FeatureSpawnParametersVariable.asset",
	    menuName = SOArchitecture_Utility.VARIABLE_SUBMENU + "FeatureSpawnParameters Event",
	    order = 120)]
	public class FeatureSpawnParametersVariable : BaseVariable<FeatureSpawnParameters, FeatureSpawnParametersEvent>
	{
	}
}