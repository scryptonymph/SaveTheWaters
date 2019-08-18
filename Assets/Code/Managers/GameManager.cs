using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaveTheWaters {
    public class GameManager : MonoBehaviour {

        public static GameManager Instance { get; private set; }

        private SaveManager _saveManager;

        private void Awake() {
            if(Instance != null && Instance != this) {
                Destroy(this.gameObject);

                return;
            }

            Instance = this;

            DontDestroyOnLoad(this.gameObject);
        }

        private void Start() {
            _saveManager = SaveManager.Instance;

            _saveManager.LoadData();
        }

        private void OnApplicationQuit() {
            _saveManager.SaveData();
        }

        private void OnApplicationPause(bool pause) {
            if(pause) {
                _saveManager.SaveData();
            }
        }
    }
}
