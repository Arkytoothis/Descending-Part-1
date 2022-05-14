using UnityEngine;
using Descending.World;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class TreasureReference : BaseReference<TreasureChest, TreasureVariable>
	{
	    public TreasureReference() : base() { }
	    public TreasureReference(TreasureChest value) : base(value) { }
	}
}