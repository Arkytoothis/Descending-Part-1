using Descending.Party;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class PartySpawnerReference : BaseReference<PartySpawner, PartySpawnerVariable>
	{
	    public PartySpawnerReference() : base() { }
	    public PartySpawnerReference(PartySpawner value) : base(value) { }
	}
}