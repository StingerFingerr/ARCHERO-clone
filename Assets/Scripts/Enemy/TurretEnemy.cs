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

            StartCoroutine(Move());
        }

        private void OnDisable()
        {
            StopAllCoroutines();
        }

        private void Update()
        {
            Vector3 rot = Player.Instance.Position - transform.position;
            transform.rotation = Quaternion.LookRotation(new Vector3(rot.x,0,rot.z) , Vector3.up);
        }

        protected override IEnumerator Attack()
        {
            _weapon.Fire(weaponTransform);
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


    }
}