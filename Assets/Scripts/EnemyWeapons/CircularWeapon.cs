using UnityEngine;

namespace DefaultNamespace.EnemyWeapons.EnemyBullets
{
    [CreateAssetMenu(menuName = "EnemyWeapons/CircularWeapon",fileName = "CircularEnemyWeapon", order = 1)]
    public class CircularWeapon: BaseBulletWeapon
    {
        public override void Fire(Transform weaponTransform)
        {
            throw new System.NotImplementedException();
        }
    }
}