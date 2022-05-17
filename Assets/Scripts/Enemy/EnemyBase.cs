using System;
using System.Collections;
using System.Collections.Generic;
using Enemy;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Events;

public abstract class EnemyBase : MonoBehaviour, ITarget, IDamaged
{
    public class TargetEvent : UnityEvent<ITarget> { }

    [SerializeField] protected EnemyHpBar _healthBar;
    [SerializeField] protected int _maxHealth;
    protected float _currentMaxHealth;
    protected float _currentHealth;
    [SerializeField] public AudioClip _attackClip;
    

    protected bool _isAlive;
    public abstract bool IsVisible { get; set; }
    
    public static readonly TargetEvent OnEnemyKilled = new TargetEvent();

    protected void Awake()
    {
        _currentMaxHealth = _maxHealth;
    }

    public abstract void Attack();

    public bool IsAlive
    {
        get => _isAlive;
        set => _isAlive = value;
    }

    public Vector3 GetPosition() => transform.position;
    public Transform GetTransform() => transform;

    public virtual void SetDamage(int damage)
    {
        if(!_isAlive)
            return;
        _currentHealth -= damage;
            
        _healthBar?.SetNormalizedValue(_currentHealth/(float)_maxHealth);
            
        if (_currentHealth <= 0)
            Death();
    }

    public Player GetTarget()
    {
        return Player.Instance;
    }

    protected virtual void Death()
    {
        _isAlive = false;
        OnEnemyKilled.Invoke(this);
        gameObject.SetActive(false);
    }

    protected void ResetOnEnable()
    {
        _currentHealth = _currentMaxHealth;
        _isAlive = true;
        IsVisible = true;
    }
}
