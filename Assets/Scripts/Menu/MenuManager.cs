using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {
    public Slider progress;
    private AsyncOperation load;

    public void Start () {
        load = SceneManager.LoadSceneAsync("Game");
        load.allowSceneActivation = false;
    }
    public void Update () {
        progress.value = load.progress;
    }

    public void OnPlay () {
        if (load.progress == 0.9f) {
            load.allowSceneActivation = true;
        }
    }

    public void OnExit () {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
