using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PasswordImage : MonoBehaviour {

    public Sprite[] images = {};
    public GameObject imageObject;
    private int currentIndex = 0;

    public void Add() {
        currentIndex += 1;
        if (currentIndex >= imageObject.GetComponent<PasswordImage>().images.Length) {
            currentIndex = 0;
        }
        gameObject.GetComponent<Image>().sprite = imageObject.GetComponent<PasswordImage>().images[currentIndex];
    }
}
