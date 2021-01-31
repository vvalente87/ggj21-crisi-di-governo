using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class INPanelAnimation : MonoBehaviour {
    private RectTransform _rectTransform;

    private void Awake() {
        _rectTransform = gameObject.GetComponent<RectTransform>();
    }

    // Start is called before the first frame update
    void OnEnable() {
        _rectTransform.DOAnchorPos(new Vector2(_rectTransform.anchoredPosition.x, 0f), 1f).SetEase(Ease.OutBounce);
    }

    // Update is called once per frame
    void Update() {
    }
}