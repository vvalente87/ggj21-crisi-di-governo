using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverManager : MonoBehaviour {
    [SerializeField] private GameObject popup;
    [SerializeField] private TextMeshProUGUI message;

    private LevelManager _levelManager;

    void Awake() {
        _levelManager = FindObjectOfType<LevelManager>();
    }

    public void ActivePopup() {
        GameState.Instance.CurrentState = GameState.State.GameOver;
        if (_levelManager.Level == 0) {
            message.text = $"Non sei arrivato a fine legislatura";
        }
        else {
            message.text = $"Sei stato sfiduciato alla {_levelManager.RomanLevel} legislatura";
        }

        popup.SetActive(true);
    }
}