using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class RangeAttackState : State
{
    [SerializeField] private float _attackCooldown = 3f;

    private EnemyBase _thisEnemy;
    private float _passedTime;

    private void Awake()
    {
        Animator = GetComponent<Animator>();
        _thisEnemy = GetComponent<EnemyBase>();
    }

    private void OnEnable()
    {
        _passedTime = 0;
    }

    private void Update()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation,
                           Quaternion.LookRotation(Player.Instance.Position - transform.position), Time.deltaTime * 10);
        if (_passedTime >= _attackCooldown)
        {
            Animator.Play($"{transform.name}Attacking");
            _thisEnemy.Attack();
            _passedTime = 0;
        }
        _passedTime += Time.deltaTime;
    }
}
