using System;
using System.Diagnostics;
using Enemy;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    [RequireComponent(typeof(Rigidbody))]
    public class Player: MonoBehaviour
    {
        private enum State
        {
            Attack,
            Run,
            Idle
        }
        
        [SerializeField] private FixedJoystick _fixedJoystick;
        [SerializeField] private float _movingSpeed;
        [SerializeField][Range(.01f,.9f)] private float _validJoystickDistance = .2f;
        
        public static Player Instance;
        public Vector3 Position => transform.position;

        private Rigidbody _rb;

        private Animator _animator;
        private State currentState;

        private GameObject[] _enemies;
        private int _enemiesCount;
        
        private void Awake()
        {
            Instance = this;

            _rb = GetComponent<Rigidbody>();
            _animator = GetComponent<Animator>();

            _enemies = GameObject.FindGameObjectsWithTag("Enemy"); ////// bad
            _enemiesCount = _enemies.Length;
        }

        private void FixedUpdate()
        {
            Vector3 moveDir = new Vector3(_fixedJoystick.Horizontal, 0, _fixedJoystick.Vertical);
            SetState(moveDir);

            if (moveDir.magnitude <= _validJoystickDistance)
                moveDir = Vector3.zero;
            else
                moveDir = moveDir.normalized;
            
            switch (currentState)
            {
                case State.Attack:
                    
                    break;
                case State.Run:
                    Move(moveDir);
                    break;
                default:
                    
                    break;
            }
        }


        private void Move(Vector3 moveDir)
        {
            if(moveDir==Vector3.zero)
                return;
            transform.localRotation = Quaternion.LookRotation(moveDir);
            _rb.velocity = moveDir * _movingSpeed;
        }
        private void SetState(Vector3 moveDir)
        {
            State previousState = currentState;
            if (moveDir == Vector3.zero)
                currentState = _enemiesCount <= 0 ? State.Idle : State.Attack;
            else
                currentState = State.Run;
            
            if(previousState!=currentState)
                _animator.SetTrigger(currentState.ToString());
        }
    }
}