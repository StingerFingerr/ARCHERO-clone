using DefaultNamespace.EnemyWeapons.EnemyBullets;
using UnityEngine;

namespace DefaultNamespace.EnemyWeapons
{
    public class BurstWeapon: BaseBulletWeapon
    {
        public override void Fire(Transform weaponTransform)
        {
            Debug.Log("burst fire");
        }
    }
}