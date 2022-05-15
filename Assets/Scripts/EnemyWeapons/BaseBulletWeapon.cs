using DefaultNamespace.Object_Pooling;
using UnityEngine;

namespace DefaultNamespace.EnemyWeapons.EnemyBullets
{
    public abstract class BaseBulletWeapon: BaseEnemyWeapon
    {
        [SerializeField] private PoolManager.EnemyBulletType bulletType;
        [SerializeField][Range(0f,1f)] private float _spreadRadius;
        

        protected void ShootBullet(Transform weaponTransform)
        {
            var bullet = PoolManager.Instance.GetEnemyBullet(bulletType);
            bullet.transform.position = weaponTransform.position;
            bullet.GetComponent<BaseEnemyBullet>().RunBullet(
                Utilities.Shooting.GetVelocity(
                    weaponTransform, _spreadRadius));
        }
    }
}