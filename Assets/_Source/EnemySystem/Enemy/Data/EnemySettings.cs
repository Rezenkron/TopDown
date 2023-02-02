using UnityEngine;

namespace EnemySystem.Enemy.Data
{
    [CreateAssetMenu(fileName = "EnemySettings", menuName = "SO/EnemySettings")]
    public class EnemySettings : ScriptableObject
    {
        [field:SerializeField] public float Health { get; private set; }
        [field:SerializeField] public float Speed { get; private set; }
        [field:SerializeField] public float AttackRange { get; private set; }
    }
}
