using UnityEngine;

namespace DefaultNamespace.Object_Pooling
{
    public abstract class BasePoolObject<T>: ScriptableObject
    {
        public new abstract T GetType();
        public GameObject objectPrefab;
        public int startCapacity;
    }
}