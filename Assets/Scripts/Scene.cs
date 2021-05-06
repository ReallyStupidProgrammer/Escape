using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour {
    public void start() {
        SceneManager.LoadSceneAsync(1);
    }

    public void menu() {
        SceneManager.LoadSceneAsync(0);
    }

    public void success() {
        SceneManager.LoadSceneAsync(2);
    }

    public void quit() {
        // UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
