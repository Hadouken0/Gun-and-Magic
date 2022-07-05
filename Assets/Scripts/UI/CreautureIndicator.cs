using UnityEngine;
using UnityEngine.UI;

public class CreautureIndicator : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Text _text;
    [SerializeField] private Image _fill;

    [SerializeField] private Color defaultColor;
    [SerializeField] private Color lowValueColor;

    public void ChangeValue(float currValue, float maxValue)
    {
        _slider.value = currValue;
        _slider.maxValue = maxValue;
        _text.text = currValue + "/" + maxValue;
        _fill.color = Color.Lerp( lowValueColor, defaultColor, currValue/maxValue);
    }
    
}
