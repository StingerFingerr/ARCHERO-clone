using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class RangeEnemyMoveTransition : Transition
{
    [SerializeField] private float _maxMovingTime;

    private float _passedTime;

    protected override void Awake()
    {
        base.Awake();
    }

    private void OnEnable()
    {
        NeedToTransit = false;
    }

    private void Update()
    {       
        if (_navMeshAgent.remainingDistance == 0 || _passedTime >= _maxMovingTime)
        {
            if (_navMeshAgent.remainingDistance == 0)
                Debug.Log("RangeEnemyMoveTransition of Distance");
            else
                Debug.Log("RangeEnemyMoveTransition of time");
            _passedTime = 0;
            _navMeshAgent.ResetPath();
            NeedToTransit = true;
        }
        _passedTime += Time.deltaTime;
    }
}
