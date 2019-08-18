using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaveTheWaters {
    public class PlayerInput : MonoBehaviour {
        [SerializeField] private Plastic _plastic;

        private List<float> _timesOfInput = new List<float>();

        private void Update() {
            for(int i = 0; i < _timesOfInput.Count; i++) {
                // If time of input is over a second old, discount the input from count
                if(_timesOfInput[i] <= Time.timeSinceLevelLoad - 2) {
                    _timesOfInput.RemoveAt(i);
                }
            }

            // 1.1f times added to make the value more interesting.
            _plastic.InputPps = _timesOfInput.Count * 1.1f;
        }

        private void OnMouseDown() {
            // Records periods in time when input was received
            _timesOfInput.Add(Time.timeSinceLevelLoad);

            _plastic.UpdatePlastic();
        }
    }
}
