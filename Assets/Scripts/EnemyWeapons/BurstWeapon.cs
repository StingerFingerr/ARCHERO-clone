using System.Collections;
using DefaultNamespace.EnemyWeapons.EnemyBullets;
using DefaultNamespace.Object_Pooling;
using UnityEngine;
using UnityEngine.SocialPlatforms;

namespace DefaultNamespace.EnemyWeapons
{
    [CreateAssetMenu(menuName = "EnemyWeapons/BurstWeapon", fileName = "BurstEnemyWeapon", order = 1)]
    public class BurstWeapon: BaseBulletWeapon
    {
        [SerializeField] [Range(2, 4)] private int countInBurst = 2;
        [SerializeField] [Range(.1f, 1f)] private float _reloadTimeBetweenShots = .5f;

        public override void Fire(Transform weaponTransform)
        {
            PoolManager.Instance.StartCoroutine(FireBurst(weaponTransform));
        }

        private IEnumerator FireBurst(Transform weaponTransform)
        {
            for (int i = 0; i < countInBurst; i++)
            {
                ShootBullet(weaponTransform);
                yield return new WaitForSeconds(_reloadTimeBetweenShots);
            }
        }
    }
}