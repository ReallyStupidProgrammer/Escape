using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PasswordImage : MonoBehaviour {

    public Sprite[] images = {};
    public GameObject imageObject;
    private int currentIndex = 0;
    private int[] nums = {3, 4, 5, 6, 8};

    public int Add() {
        currentIndex += 1;
        if (currentIndex >= imageObject.GetComponent<PasswordImage>().images.Length) {
            currentIndex = 0;
        }
        gameObject.GetComponent<Image>().sprite = imageObject.GetComponent<PasswordImage>().images[currentIndex];
        return nums[currentIndex];
    }
}
