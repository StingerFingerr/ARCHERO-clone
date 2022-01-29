using UnityEngine;

namespace DefaultNamespace
{
    public static class Utilities
    {
        public static class Shooting
        {
            public static Vector3 GetVelocity(Transform weaponTransform, float spreadRadius)
            {
                Vector3 dir = Player.Instance.Position - weaponTransform.position;
                Vector3 dirXZ = new Vector3(dir.x, 0, dir.z);
                
                float x = dirXZ.magnitude;
                float y = dir.y;

                float angleInRadians = -weaponTransform.localEulerAngles.x * Mathf.PI / 180;

                float v2 = (Physics.gravity.y * x * x) / (2 * (y - Mathf.Tan(angleInRadians) * x) * Mathf.Pow(Mathf.Cos(angleInRadians),2));

                float v = Mathf.Sqrt(Mathf.Abs(v2));

                Vector3 res = weaponTransform.forward * v;

                res.x += Random.Range(-spreadRadius, spreadRadius);
                res.y += Random.Range(-spreadRadius, spreadRadius);
                res.z += Random.Range(0, spreadRadius);
                
                return res;
            }
        }

        
    }
}