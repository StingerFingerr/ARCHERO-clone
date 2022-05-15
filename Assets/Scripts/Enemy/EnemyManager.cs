using System;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

namespace Enemy
{
    public class EnemyManager: MonoBehaviour
    {
        public static EnemyManager Instance;

        private  List<ITarget> _allTargets;

        private void Awake()
        {
            if (Instance == null)
                Instance = this;

            var targetObjects = GameObject.FindGameObjectsWithTag("Enemy");
            _allTargets = new List<ITarget>(targetObjects.Length);
            foreach (var targetObject in targetObjects)
            {
                _allTargets.Add(targetObject.GetComponent<EnemyBase>());
            }
        }

        
        public bool TryGetNearestTarget(out ITarget nearestTarget)
        {
            float minDistance = float.MaxValue;
            nearestTarget = null;
            
            foreach (var target in _allTargets)
            {
                if(target is null) continue;
                if (target.IsAlive)
                    if (target.IsVisible)
                    {
                        float distance = Vector3.Distance(Player.Instance.Position, target.GetPosition());
                        if (distance < minDistance)
                        {
                            minDistance = distance;
                            nearestTarget = target;
                        }
                    } 
            }
            return !(nearestTarget is null);
        }
    }
}