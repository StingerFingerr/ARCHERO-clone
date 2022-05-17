using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHpBar : MonoBehaviour
{
    [SerializeField] private Gradient _gradient;
    [SerializeField] private Image _fillImage;
    [SerializeField] private TextMeshProUGUI _percentHpText; 
    private Slider _slider;

    private void Awake() => _slider = GetComponent<Slider>();

    public void SetNormalizedValue(float normalizedValue)
    {
        _fillImage.enabled = true;

        normalizedValue = Mathf.Clamp01(normalizedValue);
        _percentHpText.text = $"{normalizedValue*100}%";

        _slider.value = normalizedValue;
        _fillImage.color = _gradient.Evaluate(normalizedValue);
        _percentHpText.color = _gradient.Evaluate(normalizedValue);
    }

}
