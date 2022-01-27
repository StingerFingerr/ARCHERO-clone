
using UnityEngine;

namespace Enemy
{
    public interface ITarget
    {
        bool IsAlive { get; set; }
        bool IsVisible { get; set; }
        Vector3 GetPosition();
    }
}