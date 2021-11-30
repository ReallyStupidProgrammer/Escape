using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handle : MonoBehaviour {

    public GameObject blackWater;
    public Material waterMat;

    public void flush() {
        if (gameObject.GetComponent<Switch>().state) return;
        gameObject.GetComponent<AudioSource>().Play();
        gameObject.GetComponent<Switch>().state = true;
        blackWater.GetComponent<Water>().changeMat(waterMat);
        blackWater.GetComponent<BlackWater>().flag = true;
    }
}