using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class RangeAttackState : State
{
    [SerializeField] private float _delayStartingBullet = 0.5f;
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
        Vector3 dir = (Player.Instance.transform.position - transform.position).normalized;
        Quaternion lookRot = Quaternion.LookRotation(new Vector3(dir.x, 0, dir.z));
        transform.rotation = Quaternion.Lerp(transform.rotation, lookRot, Time.deltaTime*10);


        if (_passedTime >= _attackCooldown)
        {
            Animator.Play("Attacking");
            StartCoroutine(AttackWithDelay());
            _passedTime = 0;
        }
        _passedTime += Time.deltaTime;
    }

    private IEnumerator AttackWithDelay()
    {
        yield return new WaitForSeconds(_delayStartingBullet);
        _thisEnemy.Attack();
    }
}
