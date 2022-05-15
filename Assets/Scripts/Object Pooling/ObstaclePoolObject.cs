using DefaultNamespace.Object_Pooling;
using UnityEngine;

namespace DefaultNamespace.Object_Pooling
{
    [CreateAssetMenu(menuName = "ObjectPooling/ObstaclePoolOject", fileName = "PoolObjectSettings", order = 3)]
    public class ObstaclePoolObject : BasePoolObject<PoolManager.Obstacles>
    {
        [SerializeField] private PoolManager.Obstacles _obstacleType;

        public override PoolManager.Obstacles GetType()
        {
            return _obstacleType;
        }
    }
}
