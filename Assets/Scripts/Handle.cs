using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handle : MonoBehaviour {

    public GameObject water;

    public GameObject blackWater;

    public Material waterMat;

    public bool flushed = false;
    public float speed;
    public float endPosition;

    public void flush() {
        if (flushed) return;
        water.GetComponent<Water>().waterMovement(-1, endPosition, speed);
        flushed = true;
        blackWater.GetComponent<Water>().changeMat(waterMat);
    }
}