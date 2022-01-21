using System;
using DefaultNamespace.EnemyWeapons.EnemyBullets;
using DefaultNamespace.Object_Pooling;
using UnityEngine;

namespace DefaultNamespace.EnemyWeapons
{
    [CreateAssetMenu(menuName = "EnemyWeapons/SingleWeapon",fileName = "SingleEnemy", order = 1)]
    public class SingleWeapon: BaseEnemyWeapon
    {
        [SerializeField] private float _angleInDegrees;
        private float g = Physics.gravity.y;
        
        public override void Fire(Transform weaponTransform)
        {
            var bullet = PoolManager.Instance.GetEnemyBullet(bulletType);
            bullet.transform.position = weaponTransform.position;
            bullet.GetComponent<BaseEnemyBullet>().RunBullet(GetVelocity(weaponTransform));
        }

        private Vector3 GetVelocity(Transform weaponTransform)
        {
            Vector3 dir = Player.Instance.Position - weaponTransform.position;
            Vector3 dirXZ = new Vector3(dir.x, 0, dir.z);

            float x = dirXZ.magnitude;
            float y = dir.y;

            float angleInRadians = -weaponTransform.localEulerAngles.x * Mathf.PI / 180;

            float v2 = (Physics.gravity.y * x * x) / (2 * (y - Mathf.Tan(angleInRadians) * x) * Mathf.Pow(Mathf.Cos(angleInRadians),2));

            float v = Mathf.Sqrt(Mathf.Abs(v2));
            return weaponTransform.forward * v;
        }
    }
}