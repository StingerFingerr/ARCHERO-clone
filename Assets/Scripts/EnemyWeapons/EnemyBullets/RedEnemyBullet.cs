using System;
using UnityEngine;

namespace DefaultNamespace.EnemyWeapons.EnemyBullets
{
    [RequireComponent(typeof(Rigidbody),typeof(TrailRenderer))]
    public class RedEnemyBullet: BaseEnemyBullet
    {
        private TrailRenderer _tr;

        public override void RunBullet(Vector3 velocity)
        {
            base.RunBullet(velocity);
            ResetBullet();
        }

        protected override void ResetBullet()
        {
            if (_tr is null)
                _tr = GetComponent<TrailRenderer>();
            _tr.Clear();
        }

        private void OnTriggerEnter(Collider other)
        {
            ReturnToPool();
        }
    }
}