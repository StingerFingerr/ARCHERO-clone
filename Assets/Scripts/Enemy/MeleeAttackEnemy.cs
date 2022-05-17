using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DefaultNamespace.EnemyWeapons;
using UnityEngine.AI;
using DefaultNamespace;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]
public class MeleeAttackEnemy : EnemyBase
{
    public override bool IsVisible { get; set; }

    private Animator _animator;

    private void Awake()
    {
        base.Awake();
        _animator = GetComponent<Animator>();
        GameManager.OnGameStarted.AddListener(ResetOnGameStart);
        GameManager.OnNextLevelPrepared.AddListener(Upgrade);
    }

    private void ResetOnGameStart()
    {
        _currentMaxHealth = _maxHealth;
    }
    private void Upgrade(int level)
    {
        _currentMaxHealth *= 1.15f;
    }

    private void OnEnable()
    {
        ResetOnEnable();
    }

    public override void Attack()
    {
        _animator.Play($"Attacking");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            //player.ApplyDamage(); //пеюкхгнбюрэ + днаюбхрэ йнккюидеп
        }
    }
}
