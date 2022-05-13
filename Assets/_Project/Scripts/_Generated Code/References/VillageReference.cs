using UnityEngine;
using Descending.World;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class VillageReference : BaseReference<Village, VillageVariable>
	{
	    public VillageReference() : base() { }
	    public VillageReference(Village value) : base(value) { }
	}
}