using System;
using System.Linq;
using UnityEngine;

namespace DefaultNamespace.Effects
{
    [RequireComponent(typeof(ParticleSystem))]
    public class ParticleSystemController: MonoBehaviour
    {
        private ParticleSystem _particleSystem;
        private ParticleSystem[] _childrenParticleSystems;
        
        private ParticleSystem.EmissionModule _particleEmission;

        private void Awake()
        {
            _particleSystem = GetComponent<ParticleSystem>();
            _childrenParticleSystems = _particleSystem.GetComponentsInChildren<ParticleSystem>();
            
            _particleEmission = _particleSystem.emission;
        }

        public void StopEmitting()
        {
            _particleEmission.enabled = false;
            foreach (var childrenParticleSystem in _childrenParticleSystems)
            {
                var emissionModule = childrenParticleSystem.emission;
                emissionModule.enabled = false;
            }
        }

        public void ResumeEmitting()
        {
            _particleEmission.enabled = true;
            foreach (var childrenParticleSystem in _childrenParticleSystems)
            {
                var emissionModule = childrenParticleSystem.emission;
                emissionModule.enabled = true;
            }
        }
    }
}