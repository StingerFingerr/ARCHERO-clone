using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class MeleeAttackState : State
{
    [SerializeField] private float _attackCooldown = 1f;
    private float _passedTime = 0;
    private MeleeAttackEnemy _meleeAttackEnemy;

    private void Awake()
    {
        _meleeAttackEnemy = GetComponent<MeleeAttackEnemy>();
    }

    private void OnEnable()
    {
        _passedTime = 0;
        _meleeAttackEnemy.Attack();
    }

    private void Update()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation,
                           Quaternion.LookRotation(Player.Instance.Position - transform.position), Time.deltaTime * 10);
        if (_passedTime >= _attackCooldown)
        {
            _passedTime = 0;
            _meleeAttackEnemy.Attack();
        }
        _passedTime += Time.deltaTime;
    }
}
