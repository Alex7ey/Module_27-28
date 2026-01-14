using System.Collections.Generic;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private List<CurrencyButtonView> _currencyButtonPrefabs;
    [SerializeField] private WalletView _viewWallet;
   
    private Wallet _wallet = new();

    private void Awake()
    {
        foreach(CurrencyButtonView currency in _currencyButtonPrefabs)
        {
            _wallet.AddCurrency(currency.CurrencyType);
        }

        _viewWallet.Initialize(_wallet, _currencyButtonPrefabs);
    }
}
