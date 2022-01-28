using System.Collections.Generic;
using Enemy;
using UnityEngine;

namespace DefaultNamespace.Player_weapon_system
{
    public class PlayerBow: MonoBehaviour
    {
        private bool _isCanShooting;

        
        
        
        
        public void PauseShooting() => _isCanShooting = false;
        public void ContinueShooting() => _isCanShooting = true;
    }
}