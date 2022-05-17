using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class GhostApearingState : State
{
    [SerializeField] [Range(1f, 5f)] private float _horizontalWalkingRadius = 1f;
    [SerializeField] [Range(0f, 5f)] private float _verticalWalkingRadius = 1f;

    protected override void Awake()
    {
        base.Awake();
    }

    private void OnEnable()
    {
        Vector3 newPosition = GetNewDestination();
        transform.position = newPosition;
        if (Animator == null)
            Animator = GetComponent<Animator>();
        Animator.Play("Appearing");
    }

    private Vector3 GetNewDestination()
    {
        Vector3 offset = Vector3.one;
        offset.x = Random.Range(-_horizontalWalkingRadius, _horizontalWalkingRadius);
        offset.y = 0;
        offset.z = Random.Range(-_verticalWalkingRadius, _verticalWalkingRadius);
        Vector3 result = transform.position + offset;
        return result;
    }
}