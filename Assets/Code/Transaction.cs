using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class TransactionData {
    private float _money;
    private float[] _prices;
}

public class Transaction : MonoBehaviour
{
    [SerializeField] private float[] _yieldPrices;

    [SerializeField] private Plastic _plastic;

    private float _currentMoney;

    public float CurrentMoney {
        get {
            return _currentMoney;
        }
        private set {
            _currentMoney = value;
        }
    }

    private float _currentPrice;

    private void Start() {
        CurrentMoney = 10;
    }

    public void BuyYield(int days) {
        switch (days) {
            case 1:
                _currentPrice = _yieldPrices[0];
                break;
            case 3:
                _currentPrice = _yieldPrices[1];
                break;
            case 7:
                _currentPrice = _yieldPrices[2];
                break;
        }

        if (_currentPrice > CurrentMoney) {
            return;
        }

        CurrentMoney -= _currentPrice;

        Debug.Log("money " + CurrentMoney);

        _plastic.UpdatePlastic(days);
    }
}
