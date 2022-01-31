using DefaultNamespace.Object_Pooling;
using DefaultNamespace.Object_Pooling.Interfaces;
using UnityEngine;

namespace DefaultNamespace.EnemyWeapons.EnemyBullets
{
    public abstract class BaseEnemyBullet: MonoBehaviour, ILaunchedBullet, IReturnedToPool
    {
        [SerializeField] private PoolManager.EnemyBulletType type;
        [SerializeField] private int _damage;
        
        protected Rigidbody _rb;

        
        public virtual void RunBullet(Vector3 velocity)
        {
            if (_rb is null)
                _rb = GetComponent<Rigidbody>();

            _rb.velocity = velocity;
        }
        protected abstract void ResetBullet();
        
        public void ReturnToPool()
        {
            // Invoke event for PoolManager
            gameObject.SetActive(false);
        }
    }
}