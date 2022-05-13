using Descending.Party;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class PartyControllerReference : BaseReference<PartyController, PartyControllerVariable>
	{
	    public PartyControllerReference() : base() { }
	    public PartyControllerReference(PartyController value) : base(value) { }
	}
}