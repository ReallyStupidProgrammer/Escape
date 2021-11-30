using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour {

    public static float volume = 1;
    public AudioClip[] audios;

    public void playSound(int index) {
        AudioSource sound = gameObject.GetComponent<AudioSource>();
        sound.volume = volume;
        sound.clip = audios[index];
        sound.Play();
    }

    public void stopPlay() {
        AudioSource sound = gameObject.GetComponent<AudioSource>();
        sound.Stop();
    }

}