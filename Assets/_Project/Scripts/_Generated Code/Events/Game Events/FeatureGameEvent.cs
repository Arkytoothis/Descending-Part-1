using Descending.World;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	[CreateAssetMenu(
	    fileName = "FeatureGameEvent.asset",
	    menuName = SOArchitecture_Utility.GAME_EVENT + "Feature Event",
	    order = 120)]
	public sealed class FeatureGameEvent : GameEventBase<Feature>
	{
	}
}