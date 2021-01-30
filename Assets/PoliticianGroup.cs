using System.Collections;
using System.Collections.Generic;
using System.Linq;
using PoliticianStateMachine;
using UnityEngine;

public class PoliticianGroup : MonoBehaviour {
    [SerializeField] private Politician[] politicians;

    [SerializeField] private float rate = 5;
    [SerializeField] private int quantity = 3;

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
        while (true) {
            var items = _politiciansIN.OrderBy(x => _rnd.Next()).Take(quantity).ToArray();
            foreach (var politician in items) {
                politician.ForceEscape();
            }
            yield return new WaitForSeconds(rate);
        }
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
}