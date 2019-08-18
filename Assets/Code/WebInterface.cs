using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;

namespace SaveTheWaters {
    public class WebInterface : MonoBehaviour {
        public void OpenWebsite(string websiteUrl) {
            Application.OpenURL(websiteUrl);
        }

        [SerializeField] private Transaction _transaction;
        [SerializeField] private GameObject _userInputField;
        [SerializeField] private string _dataSaveUrl;

        private string _name;

        private GameObject _donationChoice;

        public GameObject DonationChoice {
            set {
                _donationChoice = value;
            }
        }

        private float _donationSum;

        public void SendToWebsite() {
            _name = _userInputField.GetComponent<TMP_InputField>().text;

            Debug.Log("name " + _name);

            _donationSum = _transaction.CurrentPrice;

            StartCoroutine(Send(_name, _donationChoice.GetComponent<TMP_Text>().text, _donationSum));

            _transaction.MakeTransaction();
        }

        IEnumerator Send(string name, string donationChoice, float donationSum) {
            WWWForm form = new WWWForm();

            form.AddField("", name);
            form.AddField("", donationChoice);
            form.AddField("", donationSum.ToString());

            UnityWebRequest www = UnityWebRequest.Post(_dataSaveUrl, form);

            yield return www.SendWebRequest();
        }
    }
}
