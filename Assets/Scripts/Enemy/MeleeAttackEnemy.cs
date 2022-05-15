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
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        ResetOnEnable();
    }

    public override void Attack()
    {
        _animator.Play($"{transform.name}Attack");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            //player.ApplyDamage(); //пеюкхгнбюрэ + днаюбхрэ йнккюидеп
        }
    }
}
