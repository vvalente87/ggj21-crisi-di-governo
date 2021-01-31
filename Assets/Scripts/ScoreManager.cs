using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class ScoreManager : MonoBehaviour {
    [FormerlySerializedAs("textMesh")] [FormerlySerializedAs("text")] [FormerlySerializedAs("_text")] [SerializeField]
    private TextMeshProUGUI scoreText;

    private int _score = 1;

    public int Score {
        get => _score;
        set {
            _score = value;
            UpdateTextScore();
        }
    }

    // Start is called before the first frame update
    void Start() {
        UpdateTextScore();
    }

    void UpdateTextScore() {
        scoreText.text = "#" + _score.ToString();
    }

    // Update is called once per frame
    void Update() {
    }
}