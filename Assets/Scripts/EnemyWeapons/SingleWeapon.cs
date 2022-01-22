using System;
using DefaultNamespace.EnemyWeapons.EnemyBullets;
using DefaultNamespace.Object_Pooling;
using UnityEngine;

namespace DefaultNamespace.EnemyWeapons
{
    [CreateAssetMenu(menuName = "EnemyWeapons/SingleWeapon",fileName = "SingleEnemyWeapon", order = 1)]
    public class SingleWeapon: BaseBulletWeapon
    {
        public override void Fire(Transform weaponTransform)
        {
            ShootBullet(weaponTransform);
        }
    }
}