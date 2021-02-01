using System.Collections;
using System.Collections.Generic;
using System.Linq;
using PoliticianStateMachine;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.SocialPlatforms;

public class PoliticianGroup : MonoBehaviour {
    public string groupName;
    [SerializeField] private Politician[] politicians;
    [SerializeField] private Vector3 MinMaxCountdown = new Vector2(10, 30);
    [SerializeField] private Vector2 MinMaxQuantity = new Vector2(0, 5);
    [SerializeField] private Vector2 MinMaxSpeedEscape = new Vector2(1, 3);
    [SerializeField] private float ReductionFactorFidelityToNextLevel = 0.15f;
    [SerializeField] private Vector2 MinMaxFidelity = new Vector2(0.25f, 0.75f);
    private float _speedEscapeEscape = 1;
    private float _fidelity;
    private List<Politician> _politiciansIN;


    private System.Random _rnd;

    public float SpeedEscape {
        get => _speedEscapeEscape;
        set => _speedEscapeEscape = value;
    }

    public float Fidelity => _fidelity;

    void Awake() {
        _politiciansIN = new List<Politician>();
        _rnd = new System.Random();
    }

    void Start() {
        _fidelity = Mathf.Max(MinMaxFidelity.y - ReductionFactorFidelityToNextLevel * LevelManager.Instance.Level, MinMaxFidelity.x);
        StartCoroutine(ReleasePolitician());
    }


    // Start is called before the first frame update
    IEnumerator ReleasePolitician() {
        yield return new WaitForSeconds(Random.Range(1.5f, 4f));
        while (true) {
            var countdown = map(_fidelity, 0, 1, MinMaxCountdown.x, MinMaxCountdown.y);
            var quantity = map(_fidelity, 1, 0, MinMaxQuantity.x, MinMaxQuantity.y);
            _speedEscapeEscape = map(_fidelity, 1, 0, MinMaxSpeedEscape.x, MinMaxSpeedEscape.y);
            Debug.Log(countdown + " " + quantity + " " + _speedEscapeEscape);
            var items = _politiciansIN.OrderBy(x => _rnd.Next()).Take((int) quantity).ToArray();
            foreach (var politician in items) {
                politician.ForceEscape();
            }


            //Fidelity = Mathf.Max(0, Fidelity - 0.1f);
            yield return new WaitForSeconds(countdown);
        }
    }


    float map(float x, float in_min, float in_max, float out_min, float out_max) {
        var value = (x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;
        //    value = Mathf.Max(value, out_min);
        //  value = Mathf.Min(value, out_max);
        return value;
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

    public void AddFidelityDelta(float delta) {
        Debug.Log(groupName + " fidelityDelta:" + delta);
        _fidelity = Mathf.Clamp01(_fidelity + delta);
        Debug.Log(groupName + " New fidelity:" + _fidelity);
    }
}