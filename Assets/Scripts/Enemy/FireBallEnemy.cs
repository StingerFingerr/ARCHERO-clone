using System;
using System.Collections;
using DefaultNamespace;
using DefaultNamespace.EnemyWeapons;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace Enemy
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class FireBallEnemy: EnemyBase
    {
        [SerializeField] private BaseEnemyWeapon _weapon;
        [SerializeField][Range(1f,5f)] private float _reloadingTime;
        [SerializeField] private Transform weaponTransform;

        [SerializeField][Range(1f,5f)] private float _horizontalWalkingRadius = 1f;
        [SerializeField][Range(0f,5f)] private float _verticalWalkingRadius = 1f;
        
        public override bool IsVisible { get; set; }

        private NavMeshAgent _navMeshAgent;


        private void Awake()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
        }

        private void Start()
        {
            _navMeshAgent.SetDestination(GetNewDestination());
        }

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
        
        
        
        protected override IEnumerator Attack()
        {
            yield return new WaitForSeconds(_reloadingTime);
            _navMeshAgent.isStopped = true;
            transform.rotation = Quaternion.LookRotation(Player.Instance.Position - transform.position);
            _weapon.Fire(weaponTransform);
            _navMeshAgent.isStopped = false;
            
            _navMeshAgent.SetDestination(GetNewDestination());
            StartCoroutine(Attack());
        }

        protected override IEnumerator Move()
        {
            StartCoroutine(Attack());
            while (true)
            {
                if (_navMeshAgent.pathStatus == NavMeshPathStatus.PathInvalid ||
                    _navMeshAgent.pathStatus == NavMeshPathStatus.PathComplete)
                {
                    transform.rotation = Quaternion.Lerp(transform.rotation,
                        Quaternion.LookRotation(Vector3.one - transform.position),Time.deltaTime);
                }
            }
            
        }

        private Vector3 GetNewDestination()
        {
            Vector3 offset = Vector3.one;
                
            offset.x = Random.Range(-_horizontalWalkingRadius, _horizontalWalkingRadius);
            offset.y = 0;
            offset.z = Random.Range(-_verticalWalkingRadius, _verticalWalkingRadius);
    
            return transform.position + offset;
        }
    }
}