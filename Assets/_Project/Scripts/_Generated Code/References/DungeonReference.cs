using UnityEngine;
using Descending.World;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class DungeonReference : BaseReference<Dungeon, DungeonVariable>
	{
	    public DungeonReference() : base() { }
	    public DungeonReference(Dungeon value) : base(value) { }
	}
}