using Descending.Combat;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class InitiativeDataListReference : BaseReference<InitiativeDataList, InitiativeDataListVariable>
	{
	    public InitiativeDataListReference() : base() { }
	    public InitiativeDataListReference(InitiativeDataList value) : base(value) { }
	}
}