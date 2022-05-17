using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingState : State
{
    private float _transitiontime;
    private float _passedTime;

    protected override void Awake()
    {
        base.Awake();
        _transitiontime = GetComponent<GhostDisappearingTransition>().TransitionTime;
    }

    private void OnEnable()
    {
        _passedTime = 0;
        if (Animator == null)
            Animator = GetComponent<Animator>();
        Animator.Play("Disappearing");
    }

    private void Update()
    {
        if (_passedTime >= _transitiontime)
        {
            _passedTime = 0;
        }
        _passedTime += Time.deltaTime;
    }
}
