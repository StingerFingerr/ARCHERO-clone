using System;
using Enemy;
using UnityEngine;

namespace DefaultNamespace
{
    public class Player: MonoBehaviour
    {
        public static Player Instance;
        
        public Vector3 Position => transform.position;

        public EnemyBase turretEnemy;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            
        }
    }
}