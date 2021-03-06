using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DefaultNamespace;
using UnityEngine.AI;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(NavMeshAgent))]
public abstract class State : MonoBehaviour
{
    [SerializeField] private List<Transition> _transitions;
    public Transform Target { get; protected set; }
    protected Animator Animator;
    protected NavMeshAgent _navMeshAgent;

    protected virtual void Awake()
    {
        Animator = GetComponent<Animator>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        Target = FindObjectOfType<Player>().transform;
        enabled = false;
    }

    public void Enter(Transform target)
    {
        if (enabled == false)
        {
            Target = target;
            enabled = true;
            foreach (var transition in _transitions)
            {
                transition.enabled = true;
                transition.Init(Target);
            }
        }
    }

    public State GetNextState()
    {
        foreach (var transition in _transitions)
        {
            if (transition.NeedToTransit == true)
            {
                return transition.TargetState;
            }
        }
        return null;
    }

    public void Exit()
    {
        if (enabled == true)
        {
            foreach (var transition in _transitions)
            {
                transition.enabled = false;
            }
            enabled = false;
        }
    }
}