using Descending.Characters;
using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public class GameEntityEvent : UnityEvent<GameEntity> { }

	[CreateAssetMenu(
	    fileName = "GameEntityVariable.asset",
	    menuName = SOArchitecture_Utility.VARIABLE_SUBMENU + "GameEntity Event",
	    order = 120)]
	public class GameEntityVariable : BaseVariable<GameEntity, GameEntityEvent>
	{
	}
}