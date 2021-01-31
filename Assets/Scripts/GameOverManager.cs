using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour {

    public GameObject popup;


    public void ActivePopup() {
        popup.SetActive(true);
    }
}
