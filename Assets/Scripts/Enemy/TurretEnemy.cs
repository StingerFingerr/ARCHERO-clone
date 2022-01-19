using System;
using System.Collections;
using DefaultNamespace;
using DefaultNamespace.EnemyWeapons;
using UnityEngine;

namespace Enemy
{
    public class TurretEnemy: EnemyBase,ITarget
    {
        [SerializeField] private int _health;
        
        [SerializeField] private BaseEnemyWeapon _weapon;
        [SerializeField] private int _reloadingTime;
        
        private void OnEnable()
        {
            _currentHealth = _health;
            _isAlive = true;
            
            if(_weapon==null)
                return;

            StartCoroutine(Move());
        }

        private void OnDisable()
        {
            StopAllCoroutines();
        }

        private void Update()
        {
            transform.rotation = Quaternion.LookRotation(Player.Instance.Position - transform.position);
        }

        protected override IEnumerator Attack()
        {
            _weapon.Fire();
            yield break;
        }
        
        protected override IEnumerator Move()
        {
            while (true)
            {
                yield return new WaitForSeconds(_reloadingTime);

                yield return Attack();
            }

        }
        
        public void SetDamage(int damage)
        {
            if(!_isAlive)
                return;
            _health -= damage;
            Debug.Log(damage);
            if (_health <= 0)
                Death();
        }

        private void Death()
        {
            _isAlive = false;
            Debug.Log("death");
        }
    }
}