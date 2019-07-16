﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

[Serializable]
public class PlasticData {
    private int _erasedPlastic;
    private float _pps;
}

public class Plastic : MonoBehaviour {
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

    private int _dayProductionMultiplier;

    private void Start() {
        PickersInUse = false;

        _tempPps = 0;

        // seconds * minutes * hours
        _dayProductionMultiplier = 60 * 60 * 24;

        StartCoroutine(UpdatePlasticContinous());
    }

    

    public void UpdatePlastic(int cost, float pps) {
        CurrentErasedPlastic += cost;

        UpdatePlasticText();

        _permanentPps += pps;

        _ppsText.text = _permanentPps.ToString("F1") + " per second";

        _eraseInterval = 1 / _permanentPps;
    }

    public void UpdatePlastic(int days) {
        CurrentErasedPlastic += Mathf.RoundToInt(_permanentPps * _dayProductionMultiplier * days);

        UpdatePlasticText();
    }

    public void UpdatePlastic() {
        CurrentErasedPlastic++;

        UpdatePlasticText();
    }

    private IEnumerator UpdatePlasticContinous() {
        yield return new WaitUntil(() => PickersInUse == true);

        while(PickersInUse) {
            yield return new WaitForSeconds(_eraseInterval);

            CurrentErasedPlastic++;

            UpdatePlasticText();
        }
    }

    private void UpdatePlasticText() {
        _erasedPlasticText.text = "<size=60%>Erased  <size=100%><voffset=-0.1em>" + CurrentErasedPlastic + "</voffset> <size=60%>plastic!";
    }

    private IEnumerator FluctuatePps(int inputPerSecond) {
        yield return new WaitUntil(() => PickersInUse == true);

        while(_tempPps < inputPerSecond) {
            _tempPps += 0.2f;

            _ppsText.text = _permanentPps + _tempPps + " per second";
        }

        while(_tempPps > 0) {
            _tempPps -= 0.2f;

            _ppsText.text = _permanentPps + _tempPps + " per second";
        }

        yield return null;
    }
}
