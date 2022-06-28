using Descending.Party;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class StockpileControllerReference : BaseReference<StockpileController, StockpileControllerVariable>
	{
	    public StockpileControllerReference() : base() { }
	    public StockpileControllerReference(StockpileController value) : base(value) { }
	}
}