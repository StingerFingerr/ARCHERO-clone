using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DefaultNamespace;
using UnityEngine.AI;

public class RangeMoveState : State
{
    [SerializeField] [Range(1f, 5f)] private float _horizontalWalkingRadius = 1f;
    [SerializeField] [Range(0f, 5f)] private float _verticalWalkingRadius = 1f;

    private void OnEnable()
    {
        _navMeshAgent.SetDestination(GetNewDestination());
    }

    private Vector3 GetNewDestination()
    {
        Vector3 offset = Vector3.one;

        offset.x = Random.Range(-_horizontalWalkingRadius, _horizontalWalkingRadius);
        offset.y = 0;
        offset.z = Random.Range(-_verticalWalkingRadius, _verticalWalkingRadius);

        Vector3 result = transform.position + offset;
        //result.x = Mathf.Clamp(result.x, -5, 5);
        //result.z = Mathf.Clamp(result.z, -8, 8);

        return result;
    }
}