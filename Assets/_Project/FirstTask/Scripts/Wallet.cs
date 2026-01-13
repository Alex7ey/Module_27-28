using System;
using System.Collections.Generic;
using UnityEngine;

public class Wallet
{
    public event Action<CurrencyType, int> CurrencyChanged;

    public Dictionary<CurrencyType, int> Currencies { get; private set; } = new();

    public void Receive(CurrencyType type, int value)
    {
        if (Currencies.ContainsKey(type) == false)
            return;

        Currencies[type] += Mathf.Abs(value);
        CurrencyChanged?.Invoke(type, Currencies[type]);

        Debug.Log($"Добавлено {value} к валюте типа {type}");
    }

    public void TrySpend(CurrencyType type, int amount)
    {
        if (Currencies.ContainsKey(type) == false)
            return;
        
        if (Currencies[type] > 0)
        {
            int amountToSubtract = Mathf.Abs(amount);
            Currencies[type] = Mathf.Max(0, Currencies[type] - amountToSubtract);

            Debug.Log($"Осталось {Currencies[type]} единиц валюты типа {type}");
            CurrencyChanged?.Invoke(type, Currencies[type]);
        }
    }

    public void AddCurrency(CurrencyType type, int value = 0)
    {
        if (Currencies.ContainsKey(type))
        {
            Debug.Log("Такая валюта уже есть в кошельке");
            return;
        }

        Currencies.Add(type, value);
        Debug.Log($"Валюта типа {type} успешно добавлена");
    }

    public void RemoveCurrency(CurrencyType type)
    {
        if (Currencies.ContainsKey(type) == false)
        {
            Debug.Log($"Валюты типа {type} нет в кошельке");
            return;
        }

        Currencies.Remove(type);
        Debug.Log($"Валюта типа {type} успешно удалена");
    }

    public int GetBalance(CurrencyType type)
    {
        if (Currencies.ContainsKey(type) == false)
        {
            Debug.Log("Такой валюты нет в кошельке");
            return 0;
        }

        return Currencies[type];
    }
}
