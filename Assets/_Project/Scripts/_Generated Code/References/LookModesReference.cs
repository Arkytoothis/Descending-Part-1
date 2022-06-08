using Descending.Core;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class LookModesReference : BaseReference<LookModes, LookModesVariable>
	{
	    public LookModesReference() : base() { }
	    public LookModesReference(LookModes value) : base(value) { }
	}
}