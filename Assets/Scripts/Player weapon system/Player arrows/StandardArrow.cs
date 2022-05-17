using System;
using Enemy;
using UnityEngine;

namespace DefaultNamespace.Player_weapon_system
{
    public class StandardArrow: PlayerBaseArrow
    {
        
        void OnTriggerEnter(Collider other)
        {
            if (other.transform.parent.TryGetComponent(out EnemyBase target))
            {
                GiveDamage(target);
                gameObject.SetActive(false);
            }
        }

        private void OnCollisionEnter(Collision other)
        {
            gameObject.SetActive(false);
        }
    }
}