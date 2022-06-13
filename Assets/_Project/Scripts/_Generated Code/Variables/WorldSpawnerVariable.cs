using Descending.World;
using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public class WorldSpawnerEvent : UnityEvent<WorldSpawner> { }

	[CreateAssetMenu(
	    fileName = "WorldSpawnerVariable.asset",
	    menuName = SOArchitecture_Utility.VARIABLE_SUBMENU + "WorldSpawner Event",
	    order = 120)]
	public class WorldSpawnerVariable : BaseVariable<WorldSpawner, WorldSpawnerEvent>
	{
	}
}