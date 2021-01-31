using System;
using System.Collections;
using System.Collections.Generic;
using PoliticianStateMachine;
using UnityEngine;

public class DestroyPolitician : MonoBehaviour {

    private ProgressBarMajority _progressBar;
    // Start is called before the first frame update
    void Awake() {
        _progressBar = FindObjectOfType<ProgressBarMajority>();
    }

    // Update is called once per frame
    void Update() {
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.GetComponent<Politician>() != null) {
            _progressBar.Decrement();
            Destroy(other.gameObject);
        }
    }
}