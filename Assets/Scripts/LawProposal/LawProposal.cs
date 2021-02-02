using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class LawProposal : MonoBehaviour {
    [SerializeField] private TMPro.TMP_Text UIText;

    [SerializeField] private Slider timeoutSlider;
    [SerializeField] private float timeout = 5;
    [SerializeField] private float proposalInterval = 5;
    [SerializeField] private PoliticianGroup _groupGreen;
    [SerializeField] private PoliticianGroup _groupWhite;
    [SerializeField] private PoliticianGroup _groupRed;

    private Image _placeholderYesR;
    private Image _placeholderYesG;
    private Image _placeholderYesW;
    private Image _placeholderNoR;
    private Image _placeholderNoG;
    private Image _placeholderNoW;

    private RectTransform _panelRect;
    private float _time;
    private bool _timeoutEnabled;

    [System.Serializable]
    public struct Law {
        public string text;
        public float fidelityAmount;
        public PoliticianGroup proposedBy;
    }

    public Law[] laws;
    private Law _currentLaw;

    // Start is called before the first frame update
    void Start() {
        _panelRect = GetComponent<RectTransform>();
        _placeholderYesR = GameObject.Find("PlaceholderYesR").GetComponent<Image>();
        _placeholderYesG = GameObject.Find("PlaceholderYesG").GetComponent<Image>();
        _placeholderYesW = GameObject.Find("PlaceholderYesW").GetComponent<Image>();
        _placeholderNoR = GameObject.Find("PlaceholderNoR").GetComponent<Image>();
        _placeholderNoG = GameObject.Find("PlaceholderNoG").GetComponent<Image>();
        _placeholderNoW = GameObject.Find("PlaceholderNoW").GetComponent<Image>();
    }

    void InitProposal() {

        GameState.Instance.CurrentState = GameState.State.Pause;
        _currentLaw = laws[Random.Range(0, laws.Length)];
        UIText.text = _currentLaw.text;
        SetPlaceholders(_currentLaw.proposedBy);

        _panelRect.DOAnchorPos(Vector2.zero, 0.5f);
        timeoutSlider.value = 1;
        _timeoutEnabled = true;
    }

    void SetPlaceholders(PoliticianGroup groupYes) {
        _placeholderYesR.gameObject.SetActive(false);
        _placeholderYesG.gameObject.SetActive(false);
        _placeholderYesW.gameObject.SetActive(false);
        _placeholderNoR.gameObject.SetActive(false);
        _placeholderNoG.gameObject.SetActive(false);
        _placeholderNoW.gameObject.SetActive(false);

        switch (groupYes.name) {
            case "Green": {
                _placeholderYesG.gameObject.SetActive(true);
                _placeholderNoR.gameObject.SetActive(true);
                _placeholderNoW.gameObject.SetActive(true);
            }
                break;
            case "Red": {
                _placeholderYesR.gameObject.SetActive(true);
                _placeholderNoG.gameObject.SetActive(true);
                _placeholderNoW.gameObject.SetActive(true);
            }
                break;
            case "White": {
                _placeholderYesW.gameObject.SetActive(true);
                _placeholderNoR.gameObject.SetActive(true);
                _placeholderNoG.gameObject.SetActive(true);
            }
                break;
            default:
                break;
        }
    }

    void Update() {       
        
        if (_timeoutEnabled) {
            if (timeoutSlider.value > 0)
                timeoutSlider.value -= Time.deltaTime / timeout;
            else {
                CloseProposal();
            }
        }
        else {
            _time += Time.deltaTime;

            if (_time >= proposalInterval && GameState.Instance.CurrentState == GameState.State.Run) {
                InitProposal();
            }
        }
    }


    public void VoteProposal(bool approved) {
        var fidelityDelta = approved ? _currentLaw.fidelityAmount : -_currentLaw.fidelityAmount;

        switch (_currentLaw.proposedBy.name) {
            case "Green": {
                _groupGreen.AddFidelityDelta(fidelityDelta);
                _groupRed.AddFidelityDelta(-fidelityDelta);
                _groupWhite.AddFidelityDelta(-fidelityDelta);
            }
                break;
            case "Red": {
                _groupGreen.AddFidelityDelta(-fidelityDelta);
                _groupRed.AddFidelityDelta(fidelityDelta);
                _groupWhite.AddFidelityDelta(-fidelityDelta);
            }
                break;
            case "White": {
                _groupGreen.AddFidelityDelta(-fidelityDelta);
                _groupRed.AddFidelityDelta(-fidelityDelta);
                _groupWhite.AddFidelityDelta(fidelityDelta);
            }
                break;
            default:
                break;
        }

        CloseProposal();
    }

    void CloseProposal() {
        GameState.Instance.CurrentState = GameState.State.Run;
        _panelRect.DOAnchorPos(new Vector2(0, 1000), 0.5f);
        _time = 0;
        _timeoutEnabled = false;
    }
}


/*
Vietato passeggiare con un cono gelato nella tasca dei pantaloni?
Vietato reincarnarsi senza autorizzazione governativa?
Predisporre uno spazio per l’atterraggio degli extraterrestri?
Un uomo che si trova costretto a urinare in pubblico, lo può fare solo se mira alla ruota posteriore della sua auto e tiene la mano destra sul veicolo?
Riconoscere la canzone Romagna mia «quale espressione popolare dei valori fondanti della nascita e dello sviluppo della Repubblica»?
Istituire lo ius primae noctis?
Istituire l'obbligo di lavarsi le ascelle prima di uscire di casa?
Vietare la professione di Ciarlatano?
Rendere illegale il canto se si è stonati?
Rendere illegale legare una banconota a un filo, lasciarla per terra, e tirarla via quando qualcuno cerca di raccoglierla?
Vietare i peti in luogo pubblico?
I gatti non possono svegliare gli esseri umani prima delle ore 6:00
Rendere illegale per un uomo con i baffi baciare una donna in pubblico?
 */