using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DefaultNamespace;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))] 
public abstract class Transition : MonoBehaviour
{
    [SerializeField] private State _targetState;

    protected NavMeshAgent _navMeshAgent;
    public Transform Target { get; protected set; }

    public State TargetState => _targetState;
    public bool NeedToTransit { get; protected set; }

    public void Init(Transform target)
    {
        Target = target;
    }

    private void OnEnable()
    {
        NeedToTransit = false;
    }

    protected virtual void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        enabled = false;
    }
}
