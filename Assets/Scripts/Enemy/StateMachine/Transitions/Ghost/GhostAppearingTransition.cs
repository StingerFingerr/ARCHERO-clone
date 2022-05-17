using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class GhostAppearingTransition : Transition
{
    private Animator _animator;

    protected override void Awake()
    {
        base.Awake();
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        NeedToTransit = false;
    }

    private void LateUpdate()
    {
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Appearing") == false)
        {
            NeedToTransit = true;
        }
    }
}
