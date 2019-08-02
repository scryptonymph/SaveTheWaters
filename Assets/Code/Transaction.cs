using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class TransactionData {
    private float _money;
    private float[] _prices;

    public float Money {
        get {
            return _money;
        }
        set {
            _money = value;
        }
    }

    public float[] Prices {
        get {
            return _prices;
        }
        set {
            _prices = value;
        }
    }
}

public class Transaction : MonoBehaviour
{
    [SerializeField] private float[] _yieldPrices;

    [SerializeField] private Plastic _plastic;

    [SerializeField] private GameObject _donationWindow;

    private float _currentMoney;

    public float CurrentMoney {
        get {
            return _currentMoney;
        }
        private set {
            _currentMoney = value;
        }
    }

    private int _yield;

    private float _currentPrice;

    public float CurrentPrice {
        get {
            return _currentPrice;
        }
    }

    private void Start() {
        CurrentMoney = 10;
    }

    public TransactionData GetData(TransactionData data) {
        data.Money = CurrentMoney;
        data.Prices = _yieldPrices;

        return data;
    }

    public void SetData(TransactionData data) {
        CurrentMoney = data.Money;
        _yieldPrices = data.Prices;
    }

    public void PrepareTransaction(int _yield) {
        switch (_yield) {
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

        if (_currentPrice > CurrentMoney || !_plastic.PickersInUse) {
            return;
        }

        _donationWindow.SetActive(true);
    }

    public void MakeTransaction() {
        CurrentMoney -= _currentPrice;

        Debug.Log("money " + CurrentMoney);

        _plastic.UpdatePlastic(_yield);
    }
}
