using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeEnemyAttackTransition : Transition
{
    [SerializeField] private float _transitionTime = 2f;

    private float _passedTime;

    private void OnEnable()
    {
        _passedTime = 0;
        NeedToTransit = false;
    }

    private void Update()
    {
        if (_passedTime >= _transitionTime)
        {
            Debug.Log("Range transit attack");
            NeedToTransit = true;
        }
        _passedTime += Time.deltaTime;
    }
}
