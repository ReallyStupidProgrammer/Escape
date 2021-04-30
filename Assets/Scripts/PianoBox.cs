using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoBox : MonoBehaviour {

    private bool opened = false;
    private IEnumerator coroutine;
    private float currentPos = 0;
    private float maxPos = -0.3f;
    private float speed = -0.001f;

    private IEnumerator openBox() {
        while (true) {
            gameObject.transform.Translate(speed, 0, 0, Space.Self);
            currentPos += speed;
            if (currentPos <= maxPos) break;
            yield return null;
        }
        StopCoroutine(coroutine);
    }

    private void open() {
        opened = true;
        print("Test");
        coroutine = openBox();
        StartCoroutine(coroutine);
    }

    private void Update() {
        if (opened) return;
        if (PianoKey.correct) open();
    }
}
