using System.Collections;
using System.Collections.Generic;
using Enemy;
using UnityEngine;
using UnityEngine.Events;

public abstract class EnemyBase : MonoBehaviour, ITarget, IDamaged
{
    public class TargetEvent : UnityEvent<ITarget> { }
    
    
    [SerializeField] protected EnemyHpBar _healthBar;
    [SerializeField] protected int _maxHealth;
    protected int _currentHealth;
    protected bool _isAlive;

    public static readonly TargetEvent OnEnemyKilled = new TargetEvent();

    protected abstract IEnumerator Attack();
    protected abstract IEnumerator Move();

    public bool IsAlive
    {
        get => _isAlive;
        set => _isAlive = value;
    }
    public abstract bool IsVisible { get; set; }
    public abstract Vector3 GetPosition();

    public abstract void SetDamage(int damage);
    protected abstract void Death();
}
