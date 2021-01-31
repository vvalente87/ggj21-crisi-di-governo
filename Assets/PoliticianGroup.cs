using System.Collections;
using System.Collections.Generic;
using System.Linq;
using PoliticianStateMachine;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class PoliticianGroup : MonoBehaviour {
    [SerializeField] private Politician[] politicians;
    [SerializeField] private Vector3 MinMaxCountdown = new Vector2(10, 30);
    [SerializeField] private Vector2 MinMaxQuantity = new Vector2(0, 5);
    [Range(0, 1)] [SerializeField] private float Fidelity;

    private List<Politician> _politiciansIN;

    private List<Politician> _politiciansOut;

    private System.Random _rnd;

    void Awake() {
        _politiciansIN = _politiciansOut = new List<Politician>();
        _rnd = new System.Random();
    }

    void Start() {
        StartCoroutine(ReleasePolitician());
    }


    // Start is called before the first frame update
    IEnumerator ReleasePolitician() {
        yield return new WaitForSeconds(1.5f);
        while (true) {
            // q=[10,40]
            //40-10 = 30
            //1-0 = 1

            //0
            //1 == 40
            //0.5 == 15

            // f [0,1]
            var quantity = map(Fidelity, 1, 0, MinMaxQuantity.x, MinMaxQuantity.y);
            var items = _politiciansIN.OrderBy(x => _rnd.Next()).Take((int) quantity).ToArray();
            foreach (var politician in items) {
                politician.ForceEscape();
            }

            var countdown = map(Fidelity, 0, 1, MinMaxCountdown.x, MinMaxCountdown.y);
            yield return new WaitForSeconds(countdown);
        }
    }


    float map(float x, float in_min, float in_max, float out_min, float out_max) {
        return (x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;
    }

    public void AddPolitician(Politician politician) {
        if (!_politiciansIN.Contains(politician))
            _politiciansIN.Add(politician);
    }

    public void RemovePolitician(Politician politician) {
        if (_politiciansIN.Contains(politician))
            _politiciansIN.Remove(politician);
    }

    private void OnValidate() {
        politicians = transform.GetComponentsInChildren<Politician>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        var politician = other.GetComponent<Politician>();
        if (politician != null && politician.Group == this) {
            other.gameObject.layer = 2;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        var politician = other.GetComponent<Politician>();
        if (politician != null && politician.Group == this) {
            other.gameObject.layer = 0;
        }
    }
}