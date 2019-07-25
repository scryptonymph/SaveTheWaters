using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

[Serializable]
public class PickerData {
    private float _pickerPps;
    private int _pickerLevel;
    private float _pickerCost;
    private bool _pickerButtonActive;
}

[Serializable]
public class PickerProperties {
    public float pps;
    public int startingCost;
    public float costRaiseRate;
}

public class Picker : MonoBehaviour
{
    //private UIManager _uiManager;

    public PickerProperties pickerProperties;

    [SerializeField] private Plastic _plastic;

    [SerializeField] private TMP_Text _shopPpsNumberText;
    [SerializeField] private TMP_Text _shopCostNumberText;
    [SerializeField] private TMP_Text _shopLevelNumberText;
    [SerializeField] private TMP_Text _levelNumberText;

    [SerializeField] private GameObject _pickerButton;

    private int _currentLevel = 0;
    private int _currentCost = 0;

    private void Start() {
        //_uiManager = UIManager.Instance;
        _shopPpsNumberText.text = pickerProperties.pps.ToString();
        _shopCostNumberText.text = pickerProperties.startingCost.ToString();

        _currentCost = pickerProperties.startingCost;
    }

    public void BuyPicker() {
        if (_currentCost > _plastic.CurrentErasedPlastic) {
            return;
        }

        if (!_pickerButton.activeInHierarchy) {
            _pickerButton.SetActive(true);
        }

        if (!_plastic.PickersInUse) {
            _plastic.PickersInUse = true;
        }

        _plastic.UpdatePlastic(-_currentCost, pickerProperties.pps);

        _currentCost = Mathf.RoundToInt(_currentCost * pickerProperties.costRaiseRate);

        _currentLevel++;

        UpdatePickerUI();
    }

    private void UpdatePickerUI() {
        _shopCostNumberText.text = _currentCost.ToString();
        _shopLevelNumberText.text = _currentLevel.ToString();
        _levelNumberText.text = _currentLevel.ToString();
    }
}
