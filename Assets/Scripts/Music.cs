using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour {

    public static float volume = 0.3f;
    public AudioClip bgm;
    public AudioClip victory;
    private AudioSource back;

    public void initialize() {
        back = this.GetComponent<AudioSource>();
        back.volume = volume;
        DontDestroyOnLoad(this.gameObject); 
    }

    private void Update() {
        back.volume = volume;
    }

    public void toBgm() {
        if (back.clip != bgm) {
            back.clip = bgm;
            back.Play();
        }
    }

    public void toVictory() {
        if (back.clip != victory) {
            back.clip = victory;
            back.Play();
        }
    }
}