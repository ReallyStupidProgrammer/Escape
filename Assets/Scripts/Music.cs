using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour {

    public static float volume = 1;
    public AudioClip music;
    private AudioSource back;

    private void Start() {
        back = this.GetComponent<AudioSource>();
        back.clip = music;
        back.volume = 1;
        back.Play();
        DontDestroyOnLoad(this.gameObject); 
    }

    private void Update() {
        back.volume = volume;
    }

}