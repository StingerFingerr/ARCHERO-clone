using UnityEngine.AI;
using UnityEngine;
using DefaultNamespace.Object_Pooling;
using System.Collections.Generic;
using System;

[RequireComponent(typeof(NavMeshSurface))]
public class SceneBuilder : MonoBehaviour
{
    [Serializable]
    public class SceneObstacleItem
    {
        public PoolManager.Obstacles obstacleType;
        public Vector3 positon;
    }
    [Serializable]
    public class SceneEnemyItem
    {
        public PoolManager.EnemyType enemyType;
        public Vector3 position;
    }
    [Serializable]
    public class SceneSetup
    {
        public List<SceneObstacleItem> sceneObstacleItems;
        public List<SceneEnemyItem> sceneEnemyItems;
    }
    [SerializeField] private List<SceneSetup> _sceneSetups;
    [SerializeField] private GameObject _portal;


    private List<GameObject> _levelItems = new List<GameObject>(10);
    private NavMeshSurface _navMeshSurface;

    private void Awake()
    {
        _navMeshSurface = GetComponent<NavMeshSurface>();

        
    }
    private void Start()
    {
        CreateLevel();
    }

    public void OpenPortal()
    {
        _portal.SetActive(true);
    }

    public void CreateLevel()
    {
        _levelItems.Clear();
        _portal.SetActive(false);

        var sceneSetup = _sceneSetups[0];
        _navMeshSurface.RemoveData();

        foreach (var obstacleItem in sceneSetup.sceneObstacleItems)
        {
            GameObject item = PoolManager.Instance.GetObstacle(obstacleItem.obstacleType);
            item.transform.position = obstacleItem.positon;
            _levelItems.Add(item);
        }
        foreach (var enemyItem in sceneSetup.sceneEnemyItems)
        {
            GameObject item = PoolManager.Instance.GetEnemy(enemyItem.enemyType);
            item.transform.position = enemyItem.position;
            _levelItems.Add(item);
        }

        _navMeshSurface.BuildNavMesh();
    }
}
