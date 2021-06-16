using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicInitializer : MonoBehaviour {

    public GameObject bgm;

    private void Start() {
        GameObject bgmInstance= GameObject.FindGameObjectWithTag("bgm");
        if (bgmInstance == null) Instantiate(bgm);
    }
}
