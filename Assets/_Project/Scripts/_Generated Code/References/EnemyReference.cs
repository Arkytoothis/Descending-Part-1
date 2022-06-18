using Descending.Enemies;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class EnemyReference : BaseReference<Enemy, EnemyVariable>
	{
	    public EnemyReference() : base() { }
	    public EnemyReference(Enemy value) : base(value) { }
	}
}