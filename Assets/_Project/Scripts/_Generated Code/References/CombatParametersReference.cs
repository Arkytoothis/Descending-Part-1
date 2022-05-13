using Descending.Combat;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class CombatParametersReference : BaseReference<CombatParameters, CombatParametersVariable>
	{
	    public CombatParametersReference() : base() { }
	    public CombatParametersReference(CombatParameters value) : base(value) { }
	}
}