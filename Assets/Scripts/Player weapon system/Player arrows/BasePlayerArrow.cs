using System;
using Enemy;
using UnityEngine;
using UnityEngine.Events;

namespace DefaultNamespace.Player_weapon_system
{
    [RequireComponent(typeof(Rigidbody))]
    public abstract class BasePlayerArrow: MonoBehaviour
    {
        [SerializeField][Range(0,10000)] protected int _damage=1;
        protected float _currentDamage;
        [SerializeField][Range(.1f,20f)] private float _speed=1;
        [SerializeField] public AudioClip _arrowLaunchClip;
        [SerializeField] public AudioClip _arrowHitClip;

        private Rigidbody _rb;

        public static UnityEvent<BasePlayerArrow> OnArrowIsLaunched = new UnityEvent<BasePlayerArrow>();
        public static UnityEvent<BasePlayerArrow> OnPlayerArrowHit = new UnityEvent<BasePlayerArrow>();

        protected void Awake()
        {
            _rb = GetComponent<Rigidbody>();

        }



        public void LaunchArrow(Vector3 direction)
        {
            direction.y = 0;
            direction.Normalize();
            
            transform.rotation = Quaternion.LookRotation(direction);
            _rb.velocity = direction * _speed;

            OnArrowIsLaunched.Invoke(this);
        }
        protected virtual void GiveDamage(IDamaged target)
        {
            target.SetDamage((int)_currentDamage);
        }
    }
}