using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHpBar : MonoBehaviour
{
    [SerializeField] private Gradient _gradient;
    [SerializeField] private Image _fillImage;
    [SerializeField] private Vector3 _posOffset;
    private Camera _mainCamera;
    private Slider _slider;

    
    private void Awake()
    {
        _mainCamera = Camera.main;
        _slider = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        _fillImage.enabled = false;
        _slider.value = 1;
    }

    public void SetNormalizedValue(float normalizedValue)
    {
        _fillImage.enabled = true;
        
        normalizedValue = Mathf.Clamp01(normalizedValue);
        
        _slider.value = normalizedValue;
        _fillImage.color = _gradient.Evaluate(normalizedValue);
    }
    
    void Update()
    {
        transform.position = _mainCamera.WorldToScreenPoint(transform.parent.parent.position + _posOffset);
    }
}
