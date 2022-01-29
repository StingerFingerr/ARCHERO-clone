using UnityEngine;

namespace DefaultNamespace.Object_Pooling
{
    [CreateAssetMenu(menuName = "ObjectPooling/EnemyBulletPoolObject",fileName = "PoolObjectSettings", order = 2)]
    public class EnemyBulletPoolObject: BasePoolObject<PoolManager.EnemyBulletType>
    {
        [SerializeField] private PoolManager.EnemyBulletType bulletType;

        public override PoolManager.EnemyBulletType GetType()
        {
            return bulletType;
        }
    }
}