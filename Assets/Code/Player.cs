using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

[Serializable]
public class PlayerData {
    private int _erasedPlastic;
    private float _pps;
    private float _money;
}

public class Player : MonoBehaviour {
    [SerializeField] private TMP_Text _erasedPlasticText;
    [SerializeField] private TMP_Text _ppsText;

    private int _currentErasedPlastic;

    public int CurrentErasedPlastic {
        get {
            return _currentErasedPlastic;
        }
        set {
            _currentErasedPlastic = value;
        }
    }

    private float _permanentPps;
    private float _eraseInterval;

    private float _inputPps;

    public float InputPps {
        get {
            return _inputPps;
        }
        set {
            _inputPps = value;
        }
    }

    private float _tempPps;

    private bool _pickersInUse;

    public bool PickersInUse {
        get {
            return _pickersInUse;
        }
        set {
            _pickersInUse = value;
        }
    }

    private void Start() {
        _pickersInUse = false;

        _tempPps = 0;

        StartCoroutine(UpdatePlasticContinous());
    }

    //private void Update() {
    //    if (_tempPps < InputPps) {
    //        _tempPps += Time.deltaTime;

    //        _ppsText.text = _permanentPps + _tempPps + " per second";
    //    } else if (_tempPps > 0) {
    //        InputPps = 0;

    //        _tempPps -= Time.deltaTime;

    //        _ppsText.text = _permanentPps + _tempPps + " per second";
    //    }
    //}

    //public IEnumerator FluctuatePps(int inputPerSecond) {
    //    while (_tempPps < inputPerSecond) {
    //        _tempPps += Time.deltaTime;

    //        _ppsText.text = _permanentPps + _tempPps + " per second";
    //    }

    //    while (_tempPps > 0) {
    //        _tempPps -= Time.deltaTime;

    //        _ppsText.text = _permanentPps + _tempPps + " per second";
    //    }

    //    yield return null;
    //}

    public void UpdatePlastic(int cost, float pps) {
        CurrentErasedPlastic += cost;

        _erasedPlasticText.text = "Erased " + _currentErasedPlastic + " plastic!";

        _permanentPps += pps;

        _ppsText.text = _permanentPps + " per second";

        _eraseInterval = 1 / _permanentPps;
    }

    public void UpdatePlastic() {
        CurrentErasedPlastic++;

        _erasedPlasticText.text = "Erased " + _currentErasedPlastic + " plastic!";
    }

    private IEnumerator UpdatePlasticContinous() {
        yield return new WaitUntil(() => PickersInUse == true);

        while(PickersInUse) {
            yield return new WaitForSeconds(_eraseInterval);

            CurrentErasedPlastic++;

            _erasedPlasticText.text = "Erased " + _currentErasedPlastic + " plastic!";
        }
    }
}
