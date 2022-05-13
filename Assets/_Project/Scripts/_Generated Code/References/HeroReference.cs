using Descending.Characters;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class HeroReference : BaseReference<Hero, HeroVariable>
	{
	    public HeroReference() : base() { }
	    public HeroReference(Hero value) : base(value) { }
	}
}