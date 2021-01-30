using UnityEngine;

public class PoliticianIdle : MonoBehaviour {
    Rigidbody2D _rigidbody;
    [SerializeField] private Vector2 force = new Vector2(1, 0);
    [SerializeField] private float repeatRate = 0.5f;

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

    void AddForce() {
        force *= -1;
        _rigidbody.AddForce(force);
    }
}