using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MeleeMoveTransition : Transition
{
    [SerializeField] private float _minTransitionDistance = 0.9f;

    private void OnEnable()
    {
        _navMeshAgent.SetDestination(Target.position);
        NeedToTransit = false;
    }

    private void Update()
    {
        if (_navMeshAgent.remainingDistance <= _minTransitionDistance)
        {
            if (Vector3.Distance(transform.position, Target.position) > _minTransitionDistance)
            {
                _navMeshAgent.SetDestination(Target.position);
            }
            else
            {
                _navMeshAgent.ResetPath();
                NeedToTransit = true;
            }
        }
    }
}
