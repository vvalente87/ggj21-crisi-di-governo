using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class Timer : MonoBehaviour {
    [SerializeField] private float countdown = 50;
    [Range(0.1f, 3)] [SerializeField] private float rate = 1;

    [FormerlySerializedAs("_timer")] [SerializeField]
    private TextMeshProUGUI timer;

    [SerializeField] private UnityEvent onFinish;

    void Start() {
        UpdateText();
        StartCoroutine(ReleasePolitician());
    }


    IEnumerator ReleasePolitician() {
        while (countdown > 0) {
            yield return new WaitForSeconds(rate);
            countdown--;
            UpdateText();
        }

        onFinish.Invoke();
        StopCoroutine(ReleasePolitician());
    }

    void UpdateText() {
        timer.text = "#" + countdown.ToString();
    }
}