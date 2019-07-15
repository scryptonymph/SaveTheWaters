using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private Plastic _plastic;

    private float _timer;
    private int _inputCounter;

    private void Update() {
        _timer += Time.deltaTime;

        if (_timer >= 1f) {
            _timer = 0;

            _plastic.InputPps = _inputCounter;

            _inputCounter = 0;
        }
    }

    private void OnMouseDown()
    {
        _inputCounter++;

        Debug.Log(_inputCounter);

        _plastic.UpdatePlastic();
    }
}
