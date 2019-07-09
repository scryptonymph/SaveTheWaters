using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

[Serializable]
public class PickerData {
    private int _pickerLevel;
    private float _pickerCost;
}

[Serializable]
public class PickerProperties {
    public float cps;
    public int startingCost;
    public float costRaiseRate;
}

public class Picker : MonoBehaviour
{
    //private UIManager _uiManager;

    public PickerProperties pickerProperties;

    [SerializeField] private Player _player;

    [SerializeField] private TMP_Text _shopCpsNumberText;
    [SerializeField] private TMP_Text _shopCostNumberText;
    [SerializeField] private TMP_Text _shopLevelNumberText;
    [SerializeField] private TMP_Text _levelNumberText;

    private int _currentLevel = 0;
    private int _currentCost = 0;
    private float _eraseInterval;

    private void Start() {
        //_uiManager = UIManager.Instance;

        _shopCpsNumberText.text = pickerProperties.cps.ToString();
        _currentCost = pickerProperties.startingCost;
        _eraseInterval = 1 / pickerProperties.cps;
    }

    public void BuyPicker() {
        if (_currentCost > _player.CurrentErasedPlastic) {
            return;
        }

        _player.ErasePlastic(-_currentCost);

        _currentCost = Mathf.RoundToInt(_currentCost * pickerProperties.costRaiseRate);

        _currentLevel++;

        UpdatePickerUI();

        StartCoroutine(ErasePlastic(_eraseInterval));
    }

    private void UpdatePickerUI() {
        _shopCostNumberText.text = _currentCost.ToString();
        _shopLevelNumberText.text = _currentLevel.ToString();
        _levelNumberText.text = _currentLevel.ToString();
    }

    private IEnumerator ErasePlastic(float time) {
        while (true) {
            yield return new WaitForSeconds(time);

            _player.ErasePlastic();
        }
    }
}
