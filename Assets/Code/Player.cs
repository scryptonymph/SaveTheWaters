using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

[Serializable]
public class PlayerData {
    private int _erasedPlastic;
    private float _cps;
    private float _money;
}

public class Player : MonoBehaviour {
    [SerializeField] private TMP_Text _erasedPlasticText;

    private int _currentErasedPlastic;

    public int CurrentErasedPlastic {
        get {
            return _currentErasedPlastic;
        }
        set {
            _currentErasedPlastic = value;
        }
    }

    public void ErasePlastic() {
        CurrentErasedPlastic++;

        _erasedPlasticText.text = "Erased " + _currentErasedPlastic + " plastic!";
    }

    public void ErasePlastic(int amount) {
        CurrentErasedPlastic += amount;

        _erasedPlasticText.text = "Erased " + _currentErasedPlastic + " plastic!";
    }
}
