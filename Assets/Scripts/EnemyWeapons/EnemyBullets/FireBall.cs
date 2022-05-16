using System;
using DefaultNamespace.Effects;
using UnityEngine;

namespace DefaultNamespace.EnemyWeapons.EnemyBullets
{
    public class FireBall: BaseEnemyBullet
    {
        [SerializeField] private GameObject _fireBallModel;
        [SerializeField] private ParticleSystemController _particleSystemController;
        [SerializeField] private ParticleSystem _explosionEffects;


        public override void RunBullet(Vector3 velocity)
        {
            ResetBullet();
            base.RunBullet(velocity);
        }

        protected override void ResetBullet()
        {
            _fireBallModel.SetActive(true);
            
            _particleSystemController.ResumeEmitting();
        }

        private void OnTriggerEnter(Collider other)
        {
            _rb.isKinematic = true;
            _explosionEffects.Play();
            _fireBallModel.SetActive(false);
            _particleSystemController?.StopEmitting();
            OnBulletHit.Invoke(this);

            Invoke( nameof(ReturnToPool), 3);
        }
    }
}