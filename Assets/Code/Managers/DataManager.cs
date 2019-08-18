using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace SaveTheWaters {
    public class DataManager : MonoBehaviour {
        public static DataManager Instance { get; private set; }

        [SerializeField] private List<Picker> _pickerList;
        [SerializeField] private Plastic _plastic;
        [SerializeField] private Transaction _transaction;

        private void Awake() {
            if(Instance != null && Instance != this) {
                Destroy(this.gameObject);

                return;
            }

            Instance = this;

            DontDestroyOnLoad(this.gameObject);
        }

        public void GetCurrentData(GameData data) {
            PlasticData plasticData = new PlasticData();

            data.PlasticData = _plastic.GetData(plasticData);

            TransactionData transactionData = new TransactionData();

            data.TransactionData = _transaction.GetData(transactionData);

            List<PickerData> pickerDatas = new List<PickerData>();

            for(int i = 0; i < _pickerList.Count; i++) {
                PickerData pickerData = new PickerData();

                pickerDatas.Add(_pickerList[i].GetData(pickerData));

                data.PickerDataList.Add(pickerDatas[i]);
            }
        }

        public void SetCurrentData(GameData data) {
            PlasticData plasticData = data.PlasticData;

            _plastic.SetData(plasticData);

            TransactionData transactionData = data.TransactionData;

            _transaction.SetData(transactionData);

            List<PickerData> pickerDatas = data.PickerDataList;

            for(int i = 0; i < _pickerList.Count; i++) {
                _pickerList[i].SetData(pickerDatas[i]);
            }
        }
    }
}
