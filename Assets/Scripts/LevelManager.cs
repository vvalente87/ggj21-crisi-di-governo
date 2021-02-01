using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class LevelManager : MonoBehaviour {
    #region SINGLETON PATTERN

    private static LevelManager _instance;

    public static LevelManager Instance {
        get {
            if (_instance == null) {
                _instance = GameObject.FindObjectOfType<LevelManager>();

                if (_instance == null) {
                    GameObject container = new GameObject("LevelManager");
                    _instance = container.AddComponent<LevelManager>();
                }
            }

            return _instance;
        }
    }

    public void OnDestroy() {
        _instance = null;
    }

    #endregion


    [FormerlySerializedAs("scoreText")] [FormerlySerializedAs("textMesh")] [FormerlySerializedAs("text")] [FormerlySerializedAs("_text")] [SerializeField]
    private TextMeshProUGUI levelText;

    [SerializeField] private GameObject winnerPopup;
    [SerializeField] private TextMeshProUGUI messageWinner;
    private static int _level;

    public int Level {
        get => _level;
        set {
            _level = value;
            UpdateLevelText();
        }
    }

    public string RomanLevel => Utils.ToRoman(_level);

    // Start is called before the first frame update
    void Start() {
        GameState.Instance.CurrentState = GameState.State.Run;
        UpdateLevelText();
    }

    public void ShowWinnerPopup() {
        GameState.Instance.CurrentState = GameState.State.Pause;
        Level++;
        messageWinner.text = $"hai superato la {RomanLevel} legislatura";
        winnerPopup.SetActive(true);
    }

    public void NextLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void UpdateLevelText() {
        levelText.text = "#" + _level.ToString();
    }
}