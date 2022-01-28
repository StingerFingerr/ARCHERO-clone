using System;
using Enemy;
using UnityEngine;

namespace DefaultNamespace.Player_weapon_system
{
    public abstract class PlayerBaseArrow: MonoBehaviour
    {
        [SerializeField][Range(0,10000)] private int _damage=1;
        [SerializeField][Range(.1f,20f)] private float _speed=1;

        protected virtual void GiveDamage(IDamaged target)
        {
            target.SetDamage(_damage);
        }
    }
}