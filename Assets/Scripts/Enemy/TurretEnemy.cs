using System;
using System.Collections;
using DefaultNamespace;
using DefaultNamespace.EnemyWeapons;
using UnityEngine;

namespace Enemy
{
    public class TurretEnemy: EnemyBase
    {
        [SerializeField] private BaseEnemyWeapon _weapon;
        [SerializeField][Range(.2f,5f)] private float _reloadingTime;
        [SerializeField] private Transform weaponTransform;
        
        public override bool IsVisible { get; set; }
        
        private void OnEnable()
        {
            ResetOnEnable();
            if(_weapon==null)
                return;
        }

        private void OnDisable()
        {
            StopAllCoroutines();
        }

        public override void Attack()
        {
            _weapon.Fire(weaponTransform);
        }
    }
}