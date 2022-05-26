using Descending.Combat;
using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public class CombatTileEvent : UnityEvent<CombatTile> { }

	[CreateAssetMenu(
	    fileName = "CombatTileVariable.asset",
	    menuName = SOArchitecture_Utility.VARIABLE_SUBMENU + "CombatTile Event",
	    order = 120)]
	public class CombatTileVariable : BaseVariable<CombatTile, CombatTileEvent>
	{
	}
}