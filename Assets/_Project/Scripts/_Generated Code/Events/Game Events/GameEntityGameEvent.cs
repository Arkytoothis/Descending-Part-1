using Descending.Characters;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	[CreateAssetMenu(
	    fileName = "GameEntityGameEvent.asset",
	    menuName = SOArchitecture_Utility.GAME_EVENT + "GameEntity Event",
	    order = 120)]
	public sealed class GameEntityGameEvent : GameEventBase<GameEntity>
	{
	}
}