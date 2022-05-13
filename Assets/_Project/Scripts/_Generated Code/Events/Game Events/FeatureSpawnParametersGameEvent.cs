using Descending;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	[CreateAssetMenu(
	    fileName = "FeatureSpawnParametersGameEvent.asset",
	    menuName = SOArchitecture_Utility.GAME_EVENT + "FeatureSpawnParameters Event",
	    order = 120)]
	public sealed class FeatureSpawnParametersGameEvent : GameEventBase<FeatureSpawnParameters>
	{
	}
}