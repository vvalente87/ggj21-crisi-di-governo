using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FidelityBar : MonoBehaviour {
    private TMPro.TMP_Text UIText;

    [SerializeField] private PoliticianGroup group;

    // Start is called before the first frame update
    void Start() {
        UIText = GetComponent<TMPro.TMP_Text>();
    }

    // Update is called once per frame
    void Update() {
        UIText.text = String.Format("Fedelta': {0:P2}", group.Fidelity);
    }
}