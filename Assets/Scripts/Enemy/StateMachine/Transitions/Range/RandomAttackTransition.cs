using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAttackTransition : Transition
{
    [SerializeField] private float _transitionTime = 2f;

    private float _passedTime;

    private void OnEnable()
    {
        NeedToTransit = false;
        _passedTime = 0;
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
