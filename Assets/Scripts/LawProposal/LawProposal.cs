using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class LawProposal : MonoBehaviour
{
    [SerializeField]
    private TMPro.TMP_Text UIText;

    [SerializeField] private Slider timeoutSlider;
    [SerializeField] private float timeout = 3;
    [SerializeField] private float proposalInterval = 5;
    private RectTransform _panelRect;
    private float _time;
    private bool _timeoutEnabled;

    [System.Serializable]
    public struct Law {
        public string text;
        public float fidelityAmount;
        public PoliticianGroup[] proposedBy;
    }

    public Law[] laws;

    // Start is called before the first frame update
    void Start()
    {
       
        _panelRect = GetComponent<RectTransform>();
       
    }

    void InitProposal()
    {
        UIText.text = laws[0].text;
        _panelRect.DOAnchorPos(Vector2.zero, 0.5f);
        timeoutSlider.value = 1;
        _timeoutEnabled = true;
    }

    void Update()
    {      
       
        if (_timeoutEnabled) {

            if (timeoutSlider.value > 0)
                timeoutSlider.value -= Time.deltaTime / timeout;
            else
            {
                CloseProposal();
            }
            print(Time.deltaTime / timeout);
        }
        else
        {
            _time += Time.deltaTime;

            if (_time >= proposalInterval)
            {
                InitProposal();
            }
        }
        
    }


    public void VoteProposal(bool approved)
    {
        CloseProposal();
    }

    void CloseProposal()
    {
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