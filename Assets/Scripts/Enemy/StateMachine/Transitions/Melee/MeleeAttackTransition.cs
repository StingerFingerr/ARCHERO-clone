using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DefaultNamespace;

public class MeleeAttackTransition : Transition
{
    [SerializeField] private float _transitionTime = 2f;
    [SerializeField] private float _minDistanceToAct = 0.9f;
    private float _passedTime = 0f;

    protected override void Awake()
    {
        base.Awake();
    }

    private void OnEnable()
    {
        NeedToTransit = false;
        _passedTime = 0f;
        if (Target == null)
            Target = FindObjectOfType<Player>().transform;
    }

    private void Update()
    {
        if (_passedTime >= _transitionTime)
        {
            NeedToTransit = true;
            _passedTime = 0f;
        }
        _passedTime += Time.deltaTime;
    }
}
