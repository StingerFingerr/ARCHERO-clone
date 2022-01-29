using System;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace.Object_Pooling
{
    public class PoolManager: MonoBehaviour
    {
        public static PoolManager Instance;
        
        public enum EnemyBulletType
        {
            RedEnemyBullet,
            FireBall,
        }

        public enum PlayerBulletType
        {
            StandardArrow,
            
        }

        [SerializeField] private List<EnemyBulletPoolObject> _enemyBulletsPoolObjects;
        private ObjectPooler<EnemyBulletType> _enemyBulletsPool;

        [SerializeField] private List<PlayerBulletPoolObject> _playerBulletsPoolObjects;
        private ObjectPooler<PlayerBulletType> _playerBulletsPool;

        private void Awake()
        {
            Instance = this;
            
            _enemyBulletsPool = new ObjectPooler<EnemyBulletType>(this, transform, 
                new List<BasePoolObject<EnemyBulletType>>(_enemyBulletsPoolObjects));
            _playerBulletsPool = new ObjectPooler<PlayerBulletType>(this, transform,
                new List<BasePoolObject<PlayerBulletType>>(_playerBulletsPoolObjects));

        }

        public GameObject GetPlayerBullet(PlayerBulletType bulletType)
        {
            return _playerBulletsPool.GetObjectFromPool(bulletType);
        }
        public GameObject GetEnemyBullet(EnemyBulletType bulletType)
        {
            return _enemyBulletsPool.GetObjectFromPool(bulletType);
        }

        public GameObject InstantiateObject(GameObject prefab, Transform holder)
        {
            return Instantiate(prefab, holder);
        }
    }
}