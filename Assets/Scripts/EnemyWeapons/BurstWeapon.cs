using UnityEngine;

namespace DefaultNamespace.EnemyWeapons
{
    public class BurstWeapon: BaseEnemyWeapon
    {
        public override void Fire()
        {
            Debug.Log("burst fire");
        }
    }
}