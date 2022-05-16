using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DefaultNamespace;

public class MeleeMoveState : State
{
    protected override void Awake()
    {
        base.Awake();
    }

    private void OnEnable()
    {
        _navMeshAgent.SetDestination(Player.Instance.transform.position);
    }
}
