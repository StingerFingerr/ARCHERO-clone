using DefaultNamespace.EnemyWeapons.EnemyBullets;
using DefaultNamespace.Object_Pooling;
using UnityEngine;

namespace DefaultNamespace.EnemyWeapons
{
    public abstract class BaseEnemyWeapon: ScriptableObject
    {
        public PoolManager.EnemyBulletType bulletType;
        
        public abstract void Fire(Transform weaponTransform);
    }
}