using Descending;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[AddComponentMenu(SOArchitecture_Utility.EVENT_LISTENER_SUBMENU + "FeatureSpawnParameters")]
	public sealed class FeatureSpawnParametersGameEventListener : BaseGameEventListener<FeatureSpawnParameters, FeatureSpawnParametersGameEvent, FeatureSpawnParametersUnityEvent>
	{
	}
}