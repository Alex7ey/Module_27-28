using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewWallet : MonoBehaviour
{
    [SerializeField] private HorizontalLayoutGroup _currencyLayoutGroup;

    private Wallet _wallet;
    private List<CurrencyButtonView> _currencyButtonViews = new();

    public void Initialize(Wallet wallet, List<CurrencyButtonView> currencyButtonView)
    {
        _wallet = wallet;

        CreateCurrencyButtons(currencyButtonView);
        SubscribeToEvents();
    }

    private void CreateCurrencyButtons(List<CurrencyButtonView> currencyButtonPrefabs)
    {
        foreach (var prefab in currencyButtonPrefabs)
        {
            CurrencyButtonView buttonView = Instantiate(prefab, _currencyLayoutGroup.transform);
            _currencyButtonViews.Add(buttonView);
        }
    }

    private void ProcessCurrencyAction(CurrencyType type, int amount)
    {
        if (amount > 0)
            _wallet.Receive(type, amount);

        else if (amount < 0)
            _wallet.TrySpend(type, -amount);
    }

    private void UpdateCurrencyBalance(CurrencyType type, int value)
    {
        foreach (var buttonView in _currencyButtonViews)
        {
            if (buttonView.CurrencyType == type)
            {
                buttonView.UpdateBalance(_wallet.GetBalance(type));
                return;
            }
        }
    }

    private void SubscribeToEvents()
    {
        foreach (var buttonView in _currencyButtonViews)
            buttonView.Clicked += ProcessCurrencyAction;

        _wallet.CurrencyChanged += UpdateCurrencyBalance;
    }

    private void UnsubscribeFromEvents()
    {
        foreach (var buttonView in _currencyButtonViews)
            buttonView.Clicked -= ProcessCurrencyAction;

        _wallet.CurrencyChanged -= UpdateCurrencyBalance;
    }

    private void OnDestroy() => UnsubscribeFromEvents();
}
