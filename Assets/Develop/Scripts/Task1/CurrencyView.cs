using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyView : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private TextMeshProUGUI _value;

    private CurrencyType _type;

    public void Initialize(CurrencyType type, Sprite icon)
    {
        _type = type;
        _icon.sprite = icon;
    }

    public void OnChangeValue(int value)
    {
        _value.text = value.ToString();
    }
}
