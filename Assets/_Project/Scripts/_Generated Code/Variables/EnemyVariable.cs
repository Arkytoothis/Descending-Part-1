using Descending.Enemies;
using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public class EnemyEvent : UnityEvent<Enemy> { }

	[CreateAssetMenu(
	    fileName = "EnemyVariable.asset",
	    menuName = SOArchitecture_Utility.VARIABLE_SUBMENU + "Enemy Event",
	    order = 120)]
	public class EnemyVariable : BaseVariable<Enemy, EnemyEvent>
	{
	}
}