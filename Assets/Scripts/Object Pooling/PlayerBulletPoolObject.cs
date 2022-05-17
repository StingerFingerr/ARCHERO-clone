using UnityEngine;

namespace DefaultNamespace.Object_Pooling
{
    [CreateAssetMenu(menuName = "ObjectPooling/PlayerBulletPoolObject",fileName = "PoolObjectSettings", order = 2)]
    public class PlayerBulletPoolObject: BasePoolObject<PoolManager.PlayerBulletType>
    {
        [SerializeField] private PoolManager.PlayerBulletType bulletType;


        public override PoolManager.PlayerBulletType GetType()
        {
            return bulletType;
        }
    }
}