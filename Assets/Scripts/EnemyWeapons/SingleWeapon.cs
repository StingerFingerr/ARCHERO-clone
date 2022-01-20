using DefaultNamespace.Object_Pooling;
using UnityEngine;

namespace DefaultNamespace.EnemyWeapons
{
    [CreateAssetMenu(menuName = "EnemyWeapons/SingleWeapon",fileName = "SingleEnemy", order = 1)]
    public class SingleWeapon: BaseEnemyWeapon
    {
        public override void Fire()
        {
            var bullet = PoolManager.Instance.GetEnemyBullet(PoolManager.EnemyBulletType.RedEnemyBullet);
            bullet.transform.position = new Vector3(0, 2, 0);
        }
    }
}