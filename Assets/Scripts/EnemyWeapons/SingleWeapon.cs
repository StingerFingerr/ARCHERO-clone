using UnityEngine;

namespace DefaultNamespace.EnemyWeapons
{
    [CreateAssetMenu(menuName = "EnemyWeapons/SingleWeapon",fileName = "SingleEnemy", order = 1)]
    public class SingleWeapon: BaseEnemyWeapon
    {
        public override void Fire()
        {
            Debug.Log("fire in "+ Player.Instance.gameObject.name);
        }
    }
}