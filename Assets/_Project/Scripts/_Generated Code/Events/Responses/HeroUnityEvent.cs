using Descending.Characters;
using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class HeroUnityEvent : UnityEvent<Hero>
	{
	}
}