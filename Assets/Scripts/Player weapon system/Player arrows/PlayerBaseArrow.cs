using System;
using Enemy;
using UnityEngine;

namespace DefaultNamespace.Player_weapon_system
{
    [RequireComponent(typeof(Rigidbody))]
    public abstract class PlayerBaseArrow: MonoBehaviour
    {
        [SerializeField][Range(0,10000)] private int _damage=1;
        [SerializeField][Range(.1f,20f)] private float _speed=1;

        private Rigidbody _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
        }

        public void SetVelocityDirection(Vector3 direction)
        {
            direction.y = 0;
            direction.Normalize();
            
            transform.rotation = Quaternion.LookRotation(direction);
            _rb.velocity = direction * _speed;
        }
        protected virtual void GiveDamage(IDamaged target)
        {
            target.SetDamage(_damage);
        }
    }
}