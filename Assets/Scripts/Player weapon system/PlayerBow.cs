using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace.Object_Pooling;
using Enemy;
using UnityEngine;

namespace DefaultNamespace.Player_weapon_system
{
    public class PlayerBow: MonoBehaviour
    {
        [SerializeField][Range(.1f,3f)] private float _reloadingTime;
        private float _currentReloadingTime;
        
        private bool _isCanShooting;

        private void Awake()
        {
            GameManager.OnGameStarted.AddListener(ResetOnGameStart);
            GameManager.OnNextLevelPrepared.AddListener(Upgrade);

            StartCoroutine(Shooting());
        }

        IEnumerator Shooting()
        {
            while (true)
            {
                if (_isCanShooting)
                {
                    var arrow = PoolManager.Instance.GetPlayerBullet(PoolManager.PlayerBulletType.StandardArrow);
                    arrow.transform.position = transform.position;
                    arrow.GetComponent<BasePlayerArrow>().LaunchArrow(transform.forward);
                    yield return new WaitForSeconds(_reloadingTime);
                }

                yield return null;
            }
        }

        private void Upgrade(int level)
        {
            _currentReloadingTime *= .9f;
        }
        private void ResetOnGameStart()
        {
            _currentReloadingTime = _reloadingTime;
        }

        public void PauseShooting() => _isCanShooting = false;
        public void ContinueShooting() => _isCanShooting = true;
    }
}