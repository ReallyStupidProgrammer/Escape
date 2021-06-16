using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicSlider : MonoBehaviour {

    public Slider slider;

    private void Start() {
        slider.value = Music.volume;
    }

    private void Update() {
        Music.volume = slider.value;
    }
}
