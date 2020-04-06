using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusbarSlider : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private int _maxValue;
    [SerializeField] private float _changeDuration = 1;

    private int _currentValue;
    private Coroutine _activeCoroutine;

    private void Start()
    {
        _slider.maxValue = _maxValue;
        _slider.value = _maxValue;
        _currentValue = _maxValue;
    }

    public void ChangeValue(int value)
    {
        _currentValue += value;
        _currentValue = Mathf.Clamp(_currentValue, 0, _maxValue);
        ChangeSliderValue();
    }

    private void ChangeSliderValue()
    {
        if (_activeCoroutine != null)
        {
            StopCoroutine(_activeCoroutine);
        }
        _activeCoroutine = StartCoroutine(ChangeSliderValueCoroutine());
    }

    private IEnumerator ChangeSliderValueCoroutine()
    {
        float startValue = _slider.value;
        float elapsed = 0;
        float nextValue;
        while (elapsed < _changeDuration)
        {
            nextValue = Mathf.Lerp(startValue, _currentValue, elapsed / _changeDuration);
            _slider.value = nextValue;
            elapsed += Time.deltaTime;
            yield return null;
        }
        _slider.value = _currentValue;
        _activeCoroutine = null;
    }

}
