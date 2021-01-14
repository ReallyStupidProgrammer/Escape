using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handle : MonoBehaviour {

    public GameObject water;

    public bool flushed = false;

    IEnumerator coroutine;

    public float endPosition;

    private IEnumerator waterFlush() {
        float currentPosition = water.transform.localPosition.y;
        while (currentPosition > endPosition) {
            yield return null;
            water.transform.Translate(0, -0.00002f, 0, Space.World);
            currentPosition = water.transform.localPosition.y;
            print(currentPosition);
        }
        flushed = true;
        StopCoroutine(coroutine);
    }

    public void flush() {
        if (flushed) return;
        print("Test");
        coroutine = waterFlush();
        StartCoroutine(coroutine);
    }
}