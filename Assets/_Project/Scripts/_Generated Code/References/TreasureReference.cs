using UnityEngine;
using Descending.World;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class TreasureReference : BaseReference<Treasure, TreasureVariable>
	{
	    public TreasureReference() : base() { }
	    public TreasureReference(Treasure value) : base(value) { }
	}
}