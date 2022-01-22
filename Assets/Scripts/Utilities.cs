using UnityEngine;

namespace DefaultNamespace
{
    public static class Utilities
    {
        public static class Shooting
        {
            public static Vector3 GetVelocity(Transform weaponTransform, Vector3 targetPosition)
            {
                Vector3 dir = targetPosition - weaponTransform.position;
                Vector3 dirXZ = new Vector3(dir.x, 0, dir.z);

                weaponTransform.parent.rotation = Quaternion.LookRotation(dirXZ); // re-aiming taking spreading
                
                float x = dirXZ.magnitude;
                float y = dir.y;

                float angleInRadians = -weaponTransform.localEulerAngles.x * Mathf.PI / 180;

                float v2 = (Physics.gravity.y * x * x) / (2 * (y - Mathf.Tan(angleInRadians) * x) * Mathf.Pow(Mathf.Cos(angleInRadians),2));

                float v = Mathf.Sqrt(Mathf.Abs(v2));
                return weaponTransform.forward * v;
            }
        }

        
    }
}