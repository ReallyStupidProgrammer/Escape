using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicInitializer : MonoBehaviour {

    public static GameObject createdBGM = null;
    public GameObject bgm;

    private void Start() {
        if (createdBGM == null) createdBGM = Instantiate(bgm);
        createdBGM.GetComponent<Music>().initialize();
        string scene_name = SceneManager.GetActiveScene().name;
        if (scene_name == "Success") createdBGM.GetComponent<Music>().toVictory();
        else createdBGM.GetComponent<Music>().toBgm();
    }
}
