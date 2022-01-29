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
            //_navMeshAgent.SetDestination(GetNewDestination());
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
            while (true)
            {
                yield return new WaitForSeconds(_reloadingTime/2);
                _navMeshAgent.ResetPath();
                yield return new WaitForSeconds(_reloadingTime/2);
                
                //transform.rotation = Quaternion.LookRotation(Player.Instance.Position - transform.position);
                _weapon.Fire(weaponTransform);
                
                
                if (_navMeshAgent.hasPath is false)
                    _navMeshAgent.SetDestination(GetNewDestination());
            }
        }

        protected override IEnumerator Move()
        {
            yield return null;
            _navMeshAgent.SetDestination(GetNewDestination());
            StartCoroutine(Attack());
            while (true)
            {
                if (_navMeshAgent.velocity.magnitude == 0)
                {
                    transform.rotation = Quaternion.Lerp(transform.rotation, 
                        Quaternion.LookRotation(Player.Instance.Position - transform.position),Time.deltaTime * 10);
                }
                yield return null;
            }
            
        }

        private Vector3 GetNewDestination()
        {
            Vector3 offset = Vector3.one;
                
            offset.x = Random.Range(-_horizontalWalkingRadius, _horizontalWalkingRadius);
            offset.y = 0;
            offset.z = Random.Range(-_verticalWalkingRadius, _verticalWalkingRadius);

            Vector3 result = transform.position + offset;
            result.x = Mathf.Clamp(result.x, -5, 5);
            result.z = Mathf.Clamp(result.z, -8, 8);
            
            return result;
        }
    }
}