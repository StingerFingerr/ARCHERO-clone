using System;
using Enemy;
using UnityEngine;

namespace DefaultNamespace.Player_weapon_system
{
    public class StandardArrow: BasePlayerArrow
    {
        private void Awake()
        {
            base.Awake();
            GameManager.OnGameStarted.AddListener(ResetOnGameStart);
            GameManager.OnNextLevelPrepared.AddListener(Upgrade);
        }
        private void Upgrade(int level)
        {
            _currentDamage *= 1.05f;
        }
        private void ResetOnGameStart()
        {
            _currentDamage = _damage;
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.transform.parent.TryGetComponent(out EnemyBase target))
            {
                GiveDamage(target);
                gameObject.SetActive(false);
            }
        }

        private void OnCollisionEnter(Collision other)
        {
            gameObject.SetActive(false);
        }
    }
}