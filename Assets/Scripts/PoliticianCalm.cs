using System.Security.Cryptography;
using UnityEngine;

public class PoliticianCalm : MonoBehaviour {
    Rigidbody2D _rigidbody;
    [SerializeField] private Vector2 force = new Vector2(1, 0);
    [SerializeField] private float repeatRate = 0.5f;

    [SerializeField] private float changeStatus = 5;

    void Awake() {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable() {
        if (enabled) {
            InvokeRepeating(nameof(AddForce), 0, repeatRate);
            Invoke(nameof(ChangeStatus), changeStatus);
        }
    }

    private void ChangeStatus() {
        var politicianEscape = gameObject.GetComponent<PoliticianEscape>();
        politicianEscape.enabled = true;
        enabled = false;
    }

    private void OnDisable() {
        CancelInvoke(nameof(AddForce));
    }

    void AddForce() {
        force *= -1;
        _rigidbody.AddForce(force);
    }
}