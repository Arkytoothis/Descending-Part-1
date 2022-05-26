using Descending.Scene_MainMenu;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class PartyManagerReference : BaseReference<PartyManager, PartyManagerVariable>
	{
	    public PartyManagerReference() : base() { }
	    public PartyManagerReference(PartyManager value) : base(value) { }
	}
}