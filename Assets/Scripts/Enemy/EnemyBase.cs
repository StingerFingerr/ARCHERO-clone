using System.Collections;
using System.Collections.Generic;
using Enemy;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    [SerializeField] protected EnemyHpBar _healthBar;
    [SerializeField] protected int _maxHealth;
    protected int _currentHealth;
    protected bool _isAlive;

    protected abstract IEnumerator Attack();
    protected abstract IEnumerator Move();
    
}
