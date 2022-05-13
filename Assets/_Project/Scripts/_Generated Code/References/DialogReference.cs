using Descending.World;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class DialogReference : BaseReference<Dialog, DialogVariable>
	{
	    public DialogReference() : base() { }
	    public DialogReference(Dialog value) : base(value) { }
	}
}