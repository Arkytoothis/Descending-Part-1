using Descending.World;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	[CreateAssetMenu(
	    fileName = "DialogGameEvent.asset",
	    menuName = SOArchitecture_Utility.GAME_EVENT + "Dialog Event",
	    order = 120)]
	public sealed class DialogGameEvent : GameEventBase<Dialog>
	{
	}
}