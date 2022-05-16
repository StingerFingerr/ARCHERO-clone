using DefaultNamespace;
using Enemy;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [SerializeField] private SceneBuilder _sceneBuilder;
    [SerializeField] private Player _player;
    [SerializeField] private Vector3 _playerStartPos;

    private int _level;
    private int _enemiesCountOnScene;
    private List<ITarget> _enemiesOnScene = new List<ITarget>();

    public static UnityEvent OnNextLevelPrepared = new UnityEvent();

    private void Awake()
    {
        EnemyBase.OnEnemyKilled.AddListener(DecrementEnemiesCount);
        PlayerHitBox.OnPlayerEntersPortal.AddListener(OpenNextLevel);
        PlayerHitBox.OnPlayerKilled.AddListener(GameOver);

        
    }

    private void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        _level = 0;
        OpenNextLevel();
    }

    private void DecrementEnemiesCount(ITarget targer)
    {
        _enemiesCountOnScene--;
        if(_enemiesCountOnScene <= 0)
        {
            _sceneBuilder.OpenPortal();
        }
    }

    private void OpenNextLevel()
    {
        _level++;
        _enemiesOnScene = _sceneBuilder.CreateLevel(_level);
        _player.SetTargets(_enemiesOnScene);
        _player.transform.position = _playerStartPos;
        OnNextLevelPrepared.Invoke();
    }

    private void GameOver()
    {

    }
}
