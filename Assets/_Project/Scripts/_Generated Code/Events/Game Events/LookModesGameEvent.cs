using Descending.Core;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	[CreateAssetMenu(
	    fileName = "LookModesGameEvent.asset",
	    menuName = SOArchitecture_Utility.GAME_EVENT + "LookModes Event",
	    order = 120)]
	public sealed class LookModesGameEvent : GameEventBase<LookModes>
	{
	}
}