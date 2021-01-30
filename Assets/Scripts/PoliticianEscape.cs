using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PoliticianEscape : MonoBehaviour {
    Rigidbody2D _rigidbody;

    [SerializeField] private float force;

    [SerializeField] private GameObject escape;

    [SerializeField] private float repeatRate = 0.5f;

    // Start is called before the first frame update
    void Awake() {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable() {
        if (enabled)
            InvokeRepeating(nameof(AddForce), 0, repeatRate);
    }


    private void OnDisable() {
        CancelInvoke(nameof(AddForce));
    }

    // Update is called once per frame
    void FixedUpdate() {
        //   var direction = (escape.transform.position - transform.position).normalized;
        //   _rigidbody.velocity = direction * force * Time.deltaTime;
    }


    void AddForce() {
        // force *= -1;
        _rigidbody.AddForce((escape.transform.position - transform.position).normalized * force);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")) {
            gameObject.GetComponent<PoliticianCalm>().enabled = true;
            enabled = false;
        }
    }
}