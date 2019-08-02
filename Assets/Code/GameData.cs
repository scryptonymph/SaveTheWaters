using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class GameData {
    private PlasticData _plasticData;
    private List<PickerData> _pickerDataList;
    private TransactionData _transactionData;

    public GameData() {
        _pickerDataList = new List<PickerData>();
    }

    public PlasticData PlasticData {
        get {
            return _plasticData;
        }
        set {
            _plasticData = value;
        }
    }

    public List<PickerData> PickerDataList {
        get {
            return _pickerDataList;
        }
        set {
            _pickerDataList = value;
        }
    }

    public TransactionData TransactionData {
        get {
            return _transactionData;
        }
        set {
            _transactionData = value;
        }
    }
}
