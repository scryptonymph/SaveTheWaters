using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    [SerializeField] private Plastic _plastic;
    
    // Update is called once per frame
    void Update()
    {
        if (_plastic.CurrentErasedPlastic > 0) {
            this.gameObject.SetActive(false);
        }
    }
}
