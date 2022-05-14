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
    public class FireBallEnemy: EnemyBase
    {
        [SerializeField] private BaseEnemyWeapon _weapon;
        [SerializeField][Range(1f,5f)] private float _reloadingTime;
        [SerializeField] private Transform weaponTransform;

        public override bool IsVisible { get; set; }

        private void OnEnable()
        {
            ResetOnEnable();
            if(_weapon==null)
                return;
        }

        public override void Attack()
        {
            _weapon.Fire(weaponTransform);
        }
    }
}