using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DefaultNamespace;

[RequireComponent(typeof(EnemyBase))]
public class EnemyBaseStateMachine : MonoBehaviour
{
    [SerializeField] private State _firstState;

    private State _currentState;
    private Player _target;

    public State CurrentState => _currentState;

    private void Start()
    {
        _target = GetComponent<EnemyBase>().GetTarget();
        Reset(_firstState);
    }

    private void OnEnable()
    {
        Reset(_firstState);
    }

    private void Update()
    {
        if (_currentState == null)
            return;
        var nextState = _currentState.GetNextState();
        if (nextState != null)
        {
            Transit(nextState);
        }
    }

    private void Reset(State startState)
    {
        if (_currentState != null)
            _currentState.Exit();
        _currentState = startState;
        if (_currentState != null)
        {
            _currentState.Enter(_target);
        }
    }

    private void Transit(State nextState)
    {
        if (_currentState != null)
        {
            _currentState.Exit();
        }
        _currentState = nextState;
        if (_currentState != null)
        {
            _currentState.Enter(_target);
        }
    }
}
