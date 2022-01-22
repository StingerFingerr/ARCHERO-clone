using System;
using UnityEngine;

namespace DefaultNamespace.EnemyWeapons.EnemyBullets
{
    [RequireComponent(typeof(Rigidbody),typeof(TrailRenderer))]
    public class RedEnemyBullet: BaseEnemyBullet
    {
        private Rigidbody _rb;
        private TrailRenderer _tr;

        public override void RunBullet(Vector3 velocity)
        {
            if (_rb == null)
                _rb = GetComponent<Rigidbody>();
            if (_tr == null)
                _tr = GetComponent<TrailRenderer>();
            
            _rb.velocity = velocity;
            _tr.Clear();
        }

        private void OnTriggerEnter(Collider other)
        {
            ReturnToPool();
        }

        private void ReturnToPool()
        {
            gameObject.SetActive(false);
        }
    }
}