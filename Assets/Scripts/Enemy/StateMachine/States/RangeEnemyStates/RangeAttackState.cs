using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class RangeAttackState : State
{
    [SerializeField] private float _attackCooldown = 3f;

    private EnemyBase _thisEnemy;
    private float _passedTime;

    protected override void Awake()
    {
        base.Awake();
        Animator = GetComponent<Animator>();
        _thisEnemy = GetComponent<EnemyBase>();
    }

    private void OnEnable()
    {
        _passedTime = 0;
    }

    private void Update()
    {
        transform.LookAt(Player.Instance.transform);
        if (transform.name.Contains("ghost"))
            Debug.Log($"{transform.name} - {transform.rotation}");
        if (_passedTime >= _attackCooldown)
        {
            Animator.Play("Attacking");
            _thisEnemy.Attack();
            _passedTime = 0;
        }
        _passedTime += Time.deltaTime;
    }
}
