using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHitBox : MonoBehaviour
{
    [SerializeField] private UIManager _UIManager;
    [SerializeField] private int _playerHealth;
    private int _remainingHealth;

    public static UnityEvent OnPlayerDamaged = new UnityEvent();
    public static UnityEvent OnPlayerKilled = new UnityEvent();
    public static UnityEvent OnPlayerEntersPortal = new UnityEvent();


    private void Awake()
    {
        GameManager.OnNextLevelPrepared.AddListener(ResetOnStartLevel);
    }

    private void ResetOnStartLevel()
    {
        _remainingHealth = _playerHealth;
        _UIManager.UpdatePlayerHP(1f);
    }

    public void SetDamage(int damage)
    {
        if (_remainingHealth <= 0)
            return;

        _remainingHealth -= damage;
        _UIManager.UpdatePlayerHP(_remainingHealth / 1f / _playerHealth);
        OnPlayerDamaged.Invoke();

        if (_remainingHealth <= 0)
            OnPlayerKilled.Invoke();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Portal"))
        {
            OnPlayerEntersPortal.Invoke();
        }
    }
}
