using UnityEngine;

namespace DefaultNamespace.EnemyWeapons.EnemyBullets
{
    public interface ILaunchedBullet
    {
        void RunBullet(Vector3 velocity);
    }
}