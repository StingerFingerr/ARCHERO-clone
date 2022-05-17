using System;
using System.Collections;
using DefaultNamespace;
using DefaultNamespace.EnemyWeapons;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace Enemy
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class RangeAttackEnemy: EnemyBase
    {
        [SerializeField] private BaseEnemyWeapon _weapon;
        [SerializeField] private Transform weaponTransform;

        public override bool IsVisible { get; set; }

        private void Awake()
        {
            base.Awake();

            GameManager.OnGameStarted.AddListener(ResetOnGameStart);
            GameManager.OnNextLevelPrepared.AddListener(Upgrade);
        }

        private void ResetOnGameStart()
        {
            _currentMaxHealth = _maxHealth;
        }
        private void Upgrade(int level)
        {
            _currentMaxHealth *= 1.15f;
        }

        private void OnEnable()
        {
            ResetOnEnable();
        }

        public override void Attack()
        {
            _weapon.Fire(weaponTransform);
        }
    }
}