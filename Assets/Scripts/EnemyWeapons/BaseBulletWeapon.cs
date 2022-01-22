using DefaultNamespace.Object_Pooling;
using UnityEngine;

namespace DefaultNamespace.EnemyWeapons.EnemyBullets
{
    public abstract class BaseBulletWeapon: BaseEnemyWeapon
    {
        [SerializeField][Range(0f,1f)] private float _spreadRadius;
        

        protected void ShootBullet(Transform weaponTransform)
        {
            var bullet = PoolManager.Instance.GetEnemyBullet(bulletType);
            bullet.transform.position = weaponTransform.position;
            bullet.GetComponent<BaseEnemyBullet>().RunBullet(
                Utilities.Shooting.GetVelocity(
                    weaponTransform, GetPositionSpread(
                        Player.Instance.Position)));
        }
        
        private Vector3 GetPositionSpread(Vector3 targetPosition)
        {
            if (_spreadRadius == 0)
                return targetPosition;
            
            Vector3 offset = Vector3.one;
                
            offset.x = Random.Range(-_spreadRadius, _spreadRadius);
            offset.y = targetPosition.y;
            offset.z = Random.Range(-_spreadRadius, _spreadRadius);
    
            return targetPosition + offset;
        }
    }
}