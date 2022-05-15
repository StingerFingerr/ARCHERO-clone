using DefaultNamespace;
using DefaultNamespace.Object_Pooling;
using UnityEngine;

[CreateAssetMenu(menuName = "ObjectPooling/EnemyPoolObject", fileName = "PoolObjectSettings", order = 4)]
public class EnemyPoolObject : BasePoolObject<PoolManager.EnemyType>
{
    [SerializeField] private PoolManager.EnemyType enemyType;
    public override PoolManager.EnemyType GetType()
    {
        return enemyType;
    }
}
