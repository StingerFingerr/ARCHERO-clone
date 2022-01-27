using DefaultNamespace.Player_weapon_system;
using Enemy;
using UnityEngine;

namespace DefaultNamespace
{
    [RequireComponent(typeof(Rigidbody))]
    public class Player: MonoBehaviour
    {
        private enum State
        {
            Attack,
            Run,
            Idle,
            Death
        }
        
        [SerializeField] private FixedJoystick _fixedJoystick;
        [SerializeField] private float _movingSpeed;
        [SerializeField][Range(.01f,.9f)] private float _validJoystickDistance = .2f;
        
        public static Player Instance;
        public Vector3 Position => transform.position;

        private Rigidbody _rb;
        private PlayerBow _playerBow;

        private Animator _animator;
        private State currentState;

        private Vector3 _nearestTargetPos;
        private ITarget _nearestTarget;
        
        private void Awake()
        {
            Instance = this;

            _rb = GetComponent<Rigidbody>();
            _animator = GetComponent<Animator>();
            _playerBow = GetComponent<PlayerBow>();

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
                    _playerBow.ContinueShooting();
                    LookRotation(_nearestTarget.GetPosition() - transform.position);
                    break;
                case State.Run:
                    _playerBow.PauseShooting();
                    Move(moveDir);
                    break;
                default:
                    _playerBow.PauseShooting();
                    break;
            }
        }

        

        private void Move(Vector3 moveDir)
        {
            if(moveDir==Vector3.zero)
                return;
            LookRotation(moveDir);
            _rb.velocity = moveDir * _movingSpeed;
        }
        private void LookRotation(Vector3 lookDir)
        {
            lookDir.y = 0;
            transform.localRotation = Quaternion.LookRotation(lookDir);
        }
        private void SetState(Vector3 moveDir)
        {
            State previousState = currentState;
            if (moveDir == Vector3.zero)
            {
                if(_nearestTarget is null)
                    if (EnemyManager.Instance.GetNearestTarget(out _nearestTarget)) 
                        currentState = State.Attack;
                    else
                     currentState = State.Idle;
            }
            else
            {
                _nearestTarget = null;
                currentState = State.Run;
            }            
            if(previousState!=currentState)
                _animator.SetTrigger(currentState.ToString());
        }
    }
}