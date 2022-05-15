using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackTransition : Transition
{
    [SerializeField] private float _transitionTime =2f;
    [SerializeField] private float _minDistanceToAct = 0.9f;
    private float _passedTime = 0f;

    private void OnEnable()
    {
        _passedTime = 0f;
        if (Vector3.Distance(transform.position, Target.position) > _minDistanceToAct)
            NeedToTransit = true;
    }

    private void Update()
    {
        if (_passedTime >= _transitionTime)
        {
            NeedToTransit = true;
        }
        _passedTime += Time.deltaTime;
    }
}
