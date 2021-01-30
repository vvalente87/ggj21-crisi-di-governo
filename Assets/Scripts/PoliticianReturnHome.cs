using System;
using UnityEngine;
using UnityEngine.Serialization;

public class PoliticianReturnHome : MonoBehaviour {
    Rigidbody2D _rigidbody;

    [SerializeField] private float speed = 5f;

    private Vector2 _startPosition;
    [SerializeField] private float minDistanceFromHome = 1;

    void Awake() {
        _rigidbody = GetComponent<Rigidbody2D>();
        _startPosition = transform.position;
    }


    private void FixedUpdate() {
        if (Vector2.Distance(_startPosition, _rigidbody.position) > minDistanceFromHome) {
            ReturnToHome();
        }
        else {
            ApplyIdleStatus();
        }
    }

    private void ApplyIdleStatus() {
        enabled = false;
        GetComponent<PoliticianIdle>().enabled = true;
    }

    private void ReturnToHome() {
        _rigidbody.MovePosition(_rigidbody.position + (_startPosition - _rigidbody.position).normalized * speed * Time.deltaTime);
    }
}