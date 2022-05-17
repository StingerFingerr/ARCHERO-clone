using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Enemy;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class MeleeAttackState : State
{

    [SerializeField] private GameObject _attackCollider;
    [SerializeField] private float _attackCooldown = 1f;
    private float _passedTime = 0;
    private MeleeAttackEnemy _meleeAttackEnemy;

    protected override void Awake()
    {
        base.Awake();
        _meleeAttackEnemy = GetComponent<MeleeAttackEnemy>();
    }

    private void OnEnable()
    {
        _passedTime = 0;
        _attackCollider.SetActive(true);
        _meleeAttackEnemy.Attack();
    }

    private void Update()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation,
                           Quaternion.LookRotation(Player.Instance.Position - transform.position), Time.deltaTime * 1);
        if (_passedTime >= _attackCooldown)
        {
            _passedTime = 0;
            _meleeAttackEnemy.Attack();
            _attackCollider.SetActive(true);
        }
        _passedTime += Time.deltaTime;
    }
}
