using UnityEngine;

namespace DefaultNamespace.EnemyWeapons
{
    public abstract class BaseEnemyWeapon: ScriptableObject
    {
        public abstract void Fire();
    }
}