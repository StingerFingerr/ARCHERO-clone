using Enemy;
using UnityEngine;

namespace DefaultNamespace.Player_weapon_system
{
    public class StandardArrow: PlayerBaseArrow
    {
        
        void OnTriggerEnter(Collider other)
        {
            if (other.transform.parent.TryGetComponent(out TurretEnemy target))
            {
                GiveDamage(target);
            }
        }
    }
}