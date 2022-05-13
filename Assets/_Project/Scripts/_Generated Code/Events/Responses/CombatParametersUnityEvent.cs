using Descending.Combat;
using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class CombatParametersUnityEvent : UnityEvent<CombatParameters>
	{
	}
}