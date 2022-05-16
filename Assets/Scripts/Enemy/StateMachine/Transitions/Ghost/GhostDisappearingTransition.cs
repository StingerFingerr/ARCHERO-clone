using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class GhostDisappearingTransition : Transition
{
    [SerializeField] private float _transitionTime;
    private float _passedTime;

    public float TransitionTime { get => _transitionTime; private set => _transitionTime = value; }

    protected override void Awake()
    {
        base.Awake();
    }

    private void OnEnable()
    {
        _passedTime = 0f;
        NeedToTransit = false;
    }

    private void LateUpdate()
    {
        if (_passedTime >= TransitionTime)
        {
            NeedToTransit = true;
        }
        _passedTime += Time.deltaTime;
    }
}
