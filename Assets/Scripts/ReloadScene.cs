using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadScene : MonoBehaviour {
    [SerializeField] private string scene;

    public void ReloadActualScene() {
        SceneManager.LoadScene(scene);
    }
}