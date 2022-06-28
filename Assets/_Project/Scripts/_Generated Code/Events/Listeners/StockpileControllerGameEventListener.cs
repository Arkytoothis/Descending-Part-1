using Descending.Party;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[AddComponentMenu(SOArchitecture_Utility.EVENT_LISTENER_SUBMENU + "StockpileController")]
	public sealed class StockpileControllerGameEventListener : BaseGameEventListener<StockpileController, StockpileControllerGameEvent, StockpileControllerUnityEvent>
	{
	}
}