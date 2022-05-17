using DefaultNamespace;
using Enemy;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [SerializeField] private SceneBuilder _sceneBuilder;
    [SerializeField] private UIManager _UIManager;
    [SerializeField] private Player _player;
    [SerializeField] private Vector3 _playerStartPos;

    private int _level;
    private int _enemiesCountOnScene;
    private List<ITarget> _enemiesOnScene = new List<ITarget>();

    public static UnityEvent OnGameStarted = new UnityEvent();
    public static UnityEvent OnNextLevelPrepared = new UnityEvent();
    
    private void Awake()
    {
        EnemyBase.OnEnemyKilled.AddListener(DecrementEnemiesCount);
        PlayerHitBox.OnPlayerEntersPortal.AddListener(OpenNextLevel);
        PlayerHitBox.OnPlayerKilled.AddListener(GameOver);

        _UIManager.OpenMenuPanel();
    }

    

    public async void StartGame()
    {
        _level = 0;
        OpenNextLevel();
        await Task.Delay(900);
        _UIManager.CloseMenuPanel();
        _UIManager.CloseGameOverPanel();

        OnGameStarted.Invoke();
    }

    private void DecrementEnemiesCount(ITarget targer)
    {
        _enemiesCountOnScene--;
        if(_enemiesCountOnScene <= 0)
        {
            _sceneBuilder.OpenPortal();
        }
    }

    private async void OpenNextLevel()
    {
        _UIManager.OpenFadedPanel();
        await Task.Delay(1000);
        _UIManager.CloseFadedPanel();
        if (_level > 1)
        {
            
        }
        _level++;
        _enemiesOnScene = _sceneBuilder.CreateLevel(_level);
        _enemiesCountOnScene = _enemiesOnScene.Count;
        _player.SetTargets(_enemiesOnScene);
        _player.transform.position = _playerStartPos;
        OnNextLevelPrepared.Invoke();
    }

    private void GameOver()
    {
        _UIManager.OpenGameOverPanel();
    }
}
