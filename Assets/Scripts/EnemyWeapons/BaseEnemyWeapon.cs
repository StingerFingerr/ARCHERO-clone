using DefaultNamespace.EnemyWeapons.EnemyBullets;
using DefaultNamespace.Object_Pooling;
using UnityEngine;

namespace DefaultNamespace.EnemyWeapons
{
    public abstract class BaseEnemyWeapon: ScriptableObject
    {
        public abstract void Fire(Transform weaponTransform);
    }
}