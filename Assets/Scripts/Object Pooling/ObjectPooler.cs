using System;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace.Object_Pooling
{
    public class ObjectPooler<T>
    {
        private List<BasePoolObject<T>> _poolObjectsSettings;
        private Dictionary<T, List<GameObject>> _pool;
        private Dictionary<T, GameObject> _prefabs;
        private Transform _objectHolder;
        private PoolManager _poolManager;

        public ObjectPooler(PoolManager poolManager, Transform objectHolder, List<BasePoolObject<T>> poolObjectsSettings)
        {
            _poolManager = poolManager;
            _objectHolder = objectHolder;
            _poolObjectsSettings = poolObjectsSettings;
            
            InitPool();
        }


        public GameObject GetObjectFromPool(T type)
        {
            if (TryGetObject(type, out GameObject objFromPool))
            {
                objFromPool.SetActive(true);
                return objFromPool;
            }
            else
            {
                var obj = CreateNewObject(type,_prefabs[type]);
                obj.SetActive(true);
                return obj;
            }
        }

        private bool TryGetObject(T type, out GameObject obj)
        {
            foreach (var objInPool in _pool[type])
            {
                if (!objInPool.activeSelf)
                {
                    obj = objInPool;
                    return true;
                }
            }

            obj = null;
            return false;
        }
        
        private GameObject CreateNewObject(T type, GameObject prefab)
        {
            var obj = _poolManager.InstantiateObject(prefab, _objectHolder);
            obj.SetActive(false);
            _pool[type].Add(obj);
            return obj;
        }
        private void InitPool()
        {
            _pool = new Dictionary<T, List<GameObject>>();
            _prefabs = new Dictionary<T, GameObject>();
            
            foreach (var poolItem in _poolObjectsSettings)
            {
                if(_pool.ContainsKey(poolItem.GetType())) continue;
                
                List<GameObject> list = new List<GameObject>(poolItem.startCapacity);
                var type = poolItem.GetType();
                _pool.Add(type,list);
                _prefabs.Add(type, poolItem.objectPrefab);
                for (int i = 0; i < poolItem.startCapacity; i++)
                {
                    CreateNewObject(type, poolItem.objectPrefab);
                }
            }
        }
    }
}