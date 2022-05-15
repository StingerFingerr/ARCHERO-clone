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
        
        private bool _isCanShooting;

        private void Awake()
        {
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
                    arrow.GetComponent<PlayerBaseArrow>().SetVelocityDirection(transform.forward);
                    yield return new WaitForSeconds(_reloadingTime);
                }

                yield return null;
            }
        }

        public void PauseShooting() => _isCanShooting = false;
        public void ContinueShooting() => _isCanShooting = true;
    }
}