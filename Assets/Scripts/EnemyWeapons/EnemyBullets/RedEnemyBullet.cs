using System;
using UnityEngine;

namespace DefaultNamespace.EnemyWeapons.EnemyBullets
{
    [RequireComponent(typeof(Rigidbody))]
    public class RedEnemyBullet: BaseEnemyBullet
    {
        private readonly float _gravityY = Physics.gravity.y;
        private float _angleInDegrees;
        
        private Rigidbody _rb;

        public override void RunBullet(Vector3 velocity)
        {
            if (_rb == null)
                _rb = GetComponent<Rigidbody>();

            _rb.velocity = velocity;
        }

        private void OnTriggerEnter(Collider other)
        {
            gameObject.SetActive(false);
        }
    }
}