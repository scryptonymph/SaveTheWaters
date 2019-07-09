using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [SerializeField] private TMP_Text _erasedPlasticText;

    private int _erasedPlastic = 0;

    private void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(this.gameObject);

            return;
        }

        Instance = this;

        //DontDestroyOnLoad(this.gameObject);
    }

    public void UpdateErasedPlastic() {
        _erasedPlastic++;

        _erasedPlasticText.text = "Erased " + _erasedPlastic + " plastic!";
    }

    public void UpdateEraseRate() {
       
    }
}
