using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSound : MonoBehaviour {

    private bool isPlaying;
    private AudioSource sound;

    private void Start() {
        isPlaying = false;
        sound = gameObject.GetComponent<AudioSource>();
        sound.Stop();
    }

    public void playSound() {
        if (isPlaying) return;
        isPlaying = true;
        sound.volume = Sounds.volume;
        sound.Play();
    }

    public void stopPlay() {
        if (!isPlaying) return;
        isPlaying = false;
        sound.Stop();
    }

}