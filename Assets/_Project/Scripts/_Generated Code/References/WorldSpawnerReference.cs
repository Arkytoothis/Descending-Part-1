using Descending.World;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class WorldSpawnerReference : BaseReference<WorldSpawner, WorldSpawnerVariable>
	{
	    public WorldSpawnerReference() : base() { }
	    public WorldSpawnerReference(WorldSpawner value) : base(value) { }
	}
}