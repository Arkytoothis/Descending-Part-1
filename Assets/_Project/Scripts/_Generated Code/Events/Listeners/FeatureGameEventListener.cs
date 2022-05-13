using Descending.World;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[AddComponentMenu(SOArchitecture_Utility.EVENT_LISTENER_SUBMENU + "Feature")]
	public sealed class FeatureGameEventListener : BaseGameEventListener<Feature, FeatureGameEvent, FeatureUnityEvent>
	{
	}
}