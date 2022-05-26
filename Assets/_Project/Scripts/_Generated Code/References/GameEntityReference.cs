using Descending.Characters;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class GameEntityReference : BaseReference<GameEntity, GameEntityVariable>
	{
	    public GameEntityReference() : base() { }
	    public GameEntityReference(GameEntity value) : base(value) { }
	}
}