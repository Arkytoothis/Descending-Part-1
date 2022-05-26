using Descending.Scene_MainMenu;
using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class PartyManagerUnityEvent : UnityEvent<PartyManager>
	{
	}
}