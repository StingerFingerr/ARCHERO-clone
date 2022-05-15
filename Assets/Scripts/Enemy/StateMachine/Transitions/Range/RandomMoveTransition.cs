using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class RandomMoveTransition : Transition
{
    [SerializeField] private float _maxMovingTime;

    private float _passedTime;

    private void Awake()
    {
        if (_navMeshAgent == null)
            _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void OnEnable()
    {
        NeedToTransit = false;
    }

    private void Update()
    {       
        if (_navMeshAgent.remainingDistance == 0 || _passedTime >= _maxMovingTime)
        {
            _passedTime = 0;
            _navMeshAgent.ResetPath();
            NeedToTransit = true;
        }
        _passedTime += Time.deltaTime;
    }
}
