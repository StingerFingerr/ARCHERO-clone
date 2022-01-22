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
            Fire,
        }

        [SerializeField] private List<EnemyBulletPoolObject> _bulletPoolObjectsList;
        private ObjectPooler<EnemyBulletType> _bulletPool;


        private void Awake()
        {
            Instance = this;
            
            _bulletPool = new ObjectPooler<EnemyBulletType>(this, transform, new List<BasePoolObject<EnemyBulletType>>(_bulletPoolObjectsList));
            
            
        }

        public GameObject GetEnemyBullet(EnemyBulletType bulletType)
        {
            return _bulletPool.GetObjectFromPool(bulletType);
        }

        public GameObject InstantiateObject(GameObject prefab, Transform holder)
        {
            return Instantiate(prefab, holder);
        }
    }
}