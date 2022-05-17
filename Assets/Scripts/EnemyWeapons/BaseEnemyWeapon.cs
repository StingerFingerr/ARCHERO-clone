using DefaultNamespace.EnemyWeapons.EnemyBullets;
using DefaultNamespace.Object_Pooling;
using UnityEngine;
using UnityEngine.Events;

namespace DefaultNamespace.EnemyWeapons
{
    public abstract class BaseEnemyWeapon: ScriptableObject
    {
        public AudioClip _shootingSound;
        public static readonly UnityEvent<BaseEnemyWeapon> OnWeaponShot = new UnityEvent<BaseEnemyWeapon>();
        public abstract void Fire(Transform weaponTransform);
    }
}