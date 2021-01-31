using System.Collections;
using System.Collections.Generic;
using PoliticianStateMachine;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ProgressBarMajority : MonoBehaviour {
    [SerializeField] private float percentageMajority = 0.5f;
    private Slider _slider;
    private int _currentPolitician;

    private int _totalPoliticianMajority;

    [SerializeField] private UnityEvent gameOver;

    // Start is called before the first frame update
    void Awake() {
        _slider = GetComponent<Slider>();
        _totalPoliticianMajority = (int) (FindObjectsOfType<Politician>().Length * percentageMajority);
        _currentPolitician = _totalPoliticianMajority;
        _slider.value = 1;
    }

    // Update is called once per frame

    public void Decrement() {
        _currentPolitician--;
        if (_currentPolitician <= 0) {
            gameOver.Invoke();
        }
        else {
            _slider.value = (float) _currentPolitician / _totalPoliticianMajority;
        }
    }
}