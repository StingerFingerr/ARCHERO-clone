using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DefaultNamespace;

public class MeleeMoveState : State
{
    private void Awake()
    {
        if (_navMeshAgent == null)
            _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void OnEnable()
    {
        _navMeshAgent.SetDestination(Target.position);
    }
}
