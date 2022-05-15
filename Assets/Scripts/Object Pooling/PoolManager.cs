using System;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace.Object_Pooling
{
    public class PoolManager: MonoBehaviour
    {
        public static PoolManager Instance;

        public enum EnemyType
        {
            Dragon,
            Skeleton
        }
        public enum EnemyBulletType
        {
            RedEnemyBullet,
            FireBall,
        }

        public enum PlayerBulletType
        {
            StandardArrow,
            
        }

        public enum Obstacles
        {
            StoneWall,
            LongStoneWall,
            Lake
        }

        [SerializeField] private List<EnemyBulletPoolObject> _enemyBulletsPoolObjects;
        private ObjectPooler<EnemyBulletType> _enemyBulletsPool;

        [SerializeField] private List<PlayerBulletPoolObject> _playerBulletsPoolObjects;
        private ObjectPooler<PlayerBulletType> _playerBulletsPool;

        [SerializeField] private List<ObstaclePoolObject> _obstaclePoolObjects;
        private ObjectPooler<Obstacles> _obstaclesPool;

        [SerializeField] private List<EnemyPoolObject> _enemyPoolObjects;
        private ObjectPooler<EnemyType> _enemiesPool;

        private void Awake()
        {
            Instance = this;
            
            _enemyBulletsPool = new ObjectPooler<EnemyBulletType>(this, transform, 
                new List<BasePoolObject<EnemyBulletType>>(_enemyBulletsPoolObjects));
            _playerBulletsPool = new ObjectPooler<PlayerBulletType>(this, transform,
                new List<BasePoolObject<PlayerBulletType>>(_playerBulletsPoolObjects));
            _obstaclesPool = new ObjectPooler<Obstacles>(this, transform,
                new List<BasePoolObject<Obstacles>>(_obstaclePoolObjects));
            _enemiesPool = new ObjectPooler<EnemyType>(this, transform,
                new List<BasePoolObject<EnemyType>>(_enemyPoolObjects));
        }

        public GameObject GetPlayerBullet(PlayerBulletType bulletType)
        {
            return _playerBulletsPool.GetObjectFromPool(bulletType);
        }
        public GameObject GetEnemyBullet(EnemyBulletType bulletType)
        {
            return _enemyBulletsPool.GetObjectFromPool(bulletType);
        }
        public GameObject GetObstacle(Obstacles obstacleType)
        {
            return _obstaclesPool.GetObjectFromPool(obstacleType);
        }
        public GameObject GetEnemy(EnemyType enemyType)
        {
            return _enemiesPool.GetObjectFromPool(enemyType);
        }

        public GameObject InstantiateObject(GameObject prefab, Transform holder)
        {
            return Instantiate(prefab, holder);
        }
    }
}