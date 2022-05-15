using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private float _maxZPos;
    [SerializeField] private float _minZPos;
    [SerializeField] private Transform _target;

    private Vector3 targetPos;

    private void Start() => targetPos = transform.position;

    void Update()
    {
        targetPos.z = Mathf.Clamp(_target.position.z, _minZPos, _maxZPos);
        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime);
    }
}
