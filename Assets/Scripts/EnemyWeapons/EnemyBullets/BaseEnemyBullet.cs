using DefaultNamespace.Object_Pooling;
using UnityEngine;

namespace DefaultNamespace.EnemyWeapons.EnemyBullets
{
    public abstract class BaseEnemyBullet: MonoBehaviour, ILaunchedBullet
    {
        [SerializeField] private PoolManager.EnemyBulletType type;
        [SerializeField] private int _damage;
        public abstract void RunBullet(Vector3 velocity);
    }
}