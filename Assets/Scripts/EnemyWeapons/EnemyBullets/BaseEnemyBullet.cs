using DefaultNamespace.Object_Pooling;
using UnityEngine;

namespace DefaultNamespace.EnemyWeapons.EnemyBullets
{
    public class BaseEnemyBullet: MonoBehaviour
    {
        [SerializeField] private PoolManager.EnemyBulletType type;
    }
}