using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    class EnemyHitBox: MonoBehaviour
    {
        [SerializeField] private int _damage = 12;
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<PlayerHitBox>(out PlayerHitBox player))
                player.SetDamage(_damage);
        }
    }
}
