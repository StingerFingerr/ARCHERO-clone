using System;
using Enemy;
using UnityEngine;

namespace DefaultNamespace
{
    [RequireComponent(typeof(Rigidbody))]
    public class Player: MonoBehaviour
    {
        [SerializeField] private FixedJoystick _fixedJoystick;
        [SerializeField] private float _movingSpeed;
        
        public static Player Instance;
        public Vector3 Position => transform.position;

        private Rigidbody _rb;
        
        private void Awake()
        {
            Instance = this;

            _rb = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            _rb.velocity = new Vector3(_fixedJoystick.Horizontal, 0, _fixedJoystick.Vertical) * _movingSpeed;
        }
    }
}