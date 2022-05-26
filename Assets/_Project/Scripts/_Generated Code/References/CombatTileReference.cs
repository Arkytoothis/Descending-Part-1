using Descending.Combat;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class CombatTileReference : BaseReference<CombatTile, CombatTileVariable>
	{
	    public CombatTileReference() : base() { }
	    public CombatTileReference(CombatTile value) : base(value) { }
	}
}