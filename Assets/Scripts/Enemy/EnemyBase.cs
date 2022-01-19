using System.Collections;
using System.Collections.Generic;
using Enemy;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    protected int _currentHealth;
    protected bool _isAlive;

    protected abstract IEnumerator Attack();
    protected abstract IEnumerator Move();
    
}
