using Descending.Combat;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	[CreateAssetMenu(
	    fileName = "CombatParametersGameEvent.asset",
	    menuName = SOArchitecture_Utility.GAME_EVENT + "CombatParameters Event",
	    order = 120)]
	public sealed class CombatParametersGameEvent : GameEventBase<CombatParameters>
	{
	}
}