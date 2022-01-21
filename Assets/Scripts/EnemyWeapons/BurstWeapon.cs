using UnityEngine;

namespace DefaultNamespace.EnemyWeapons
{
    public class BurstWeapon: BaseEnemyWeapon
    {
        public override void Fire(Transform weaponTransform)
        {
            Debug.Log("burst fire");
        }
    }
}