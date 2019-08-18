using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace SaveTheWaters {
    public class SaveManager : MonoBehaviour {
        public static SaveManager Instance { get; private set; }

        [SerializeField] private string _saveFileName = "savedata.dat";

        private string _filePath;

        private DataManager _dataManager;

        private void Awake() {
            if(Instance != null && Instance != this) {
                Destroy(this.gameObject);

                return;
            }

            Instance = this;

            DontDestroyOnLoad(this.gameObject);
        }

        private void Start() {
            _dataManager = DataManager.Instance;

            _filePath = Application.persistentDataPath + "/" + _saveFileName;
        }

        public void SaveData() {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream file = File.Create(_filePath);
            GameData data = new GameData();

            _dataManager.GetCurrentData(data);

            formatter.Serialize(file, data);

            file.Close();
        }

        public void LoadData() {
            if(File.Exists(_filePath)) {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream file = File.Open(_filePath, FileMode.Open);
                GameData data = formatter.Deserialize(file) as GameData;

                file.Close();

                _dataManager.SetCurrentData(data);
            }
        }
    }
}
