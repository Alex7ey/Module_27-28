using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyButtonView : MonoBehaviour
{
    [SerializeField] private Button _increaseButton;
    [SerializeField] private Button _decreaseButton;

    [SerializeField] private Image _currencyIcon;
    [SerializeField] private TextMeshProUGUI _balanceText;

    [SerializeField] private CurrencyType _currencyType;
    [SerializeField] private int _transactionAmount = 1;

    public event Action<CurrencyType, int> Clicked;
    public CurrencyType CurrencyType => _currencyType;

    private void Awake()
    {
        _increaseButton.onClick.AddListener(RequestIncrease);
        _decreaseButton.onClick.AddListener(RequestDecrease);
    }

    private void RequestIncrease() => Clicked?.Invoke(_currencyType, _transactionAmount);

    private void RequestDecrease() => Clicked?.Invoke(_currencyType, -_transactionAmount);

    public void UpdateBalance(int value) => _balanceText.text = value.ToString();

    private void OnDestroy()
    {
        _increaseButton.onClick.RemoveListener(RequestIncrease);
        _decreaseButton.onClick.RemoveListener(RequestDecrease);
    }
}
