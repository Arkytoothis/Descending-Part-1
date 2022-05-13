using Descending.World;
using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public class FeatureEvent : UnityEvent<Feature> { }

	[CreateAssetMenu(
	    fileName = "FeatureVariable.asset",
	    menuName = SOArchitecture_Utility.VARIABLE_SUBMENU + "Feature Event",
	    order = 120)]
	public class FeatureVariable : BaseVariable<Feature, FeatureEvent>
	{
	}
}