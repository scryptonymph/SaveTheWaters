using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

[Serializable]
public class PickerProperties
{
    public float cps;
    public int startingCost;
    public float costRaiseRate;
}

public class Picker : MonoBehaviour
{
    private UIManager _uiManager;

    public PickerProperties pickerProperties;

    [SerializeField] private TMP_Text _shopCpsNumberText;
    [SerializeField] private TMP_Text _shopCostNumberText;
    [SerializeField] private TMP_Text _shopLevelNumberText;
    [SerializeField] private TMP_Text _levelNumberText;

    private int _level = 0;
    private int _currentCost;

    private void Start() {
        _uiManager = UIManager.Instance;

        _shopCpsNumberText.text = pickerProperties.cps.ToString();
        _currentCost = pickerProperties.startingCost;
    }

    public void BuyPicker() {
        _currentCost = Mathf.RoundToInt(_currentCost * pickerProperties.costRaiseRate);

        _level++;

        UpdatePickerUI();
    }

    private void UpdatePickerUI() {
        _shopCostNumberText.text = _currentCost.ToString();
        _shopLevelNumberText.text = _level.ToString();
        _levelNumberText.text = _level.ToString();
    }

    // NEXT: FUNCTIONALITY TO ONLY BUY WHEN ENOUGH ERASED PLASTIC! + UPDATE PER SECOND TEXT, SO THE CPS NEEDS TO BE UPDATED GLOBALLY SOMEWHERE
}
