using Descending.World;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class FeatureReference : BaseReference<Feature, FeatureVariable>
	{
	    public FeatureReference() : base() { }
	    public FeatureReference(Feature value) : base(value) { }
	}
}