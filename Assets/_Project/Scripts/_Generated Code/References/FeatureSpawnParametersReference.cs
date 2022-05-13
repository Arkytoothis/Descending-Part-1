using Descending;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class FeatureSpawnParametersReference : BaseReference<FeatureSpawnParameters, FeatureSpawnParametersVariable>
	{
	    public FeatureSpawnParametersReference() : base() { }
	    public FeatureSpawnParametersReference(FeatureSpawnParameters value) : base(value) { }
	}
}