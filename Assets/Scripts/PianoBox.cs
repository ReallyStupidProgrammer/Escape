using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoBox : MonoBehaviour {

    public GameObject motorSound;
    private bool opened = false;
    private IEnumerator coroutine;
    private float currentPos = 0;
    private float maxPos = -0.3f;
    private float speed = -0.1f;

    private IEnumerator openBox() {
        motorSound.GetComponent<Sounds>().playSound(0);
        while (true) {
            gameObject.transform.Translate(speed * Time.deltaTime, 0, 0, Space.Self);
            currentPos += speed * Time.deltaTime;
            if (currentPos <= maxPos) break;
            yield return null;
        }
        StopCoroutine(coroutine);
        motorSound.GetComponent<Sounds>().stopPlay();
    }

    private void open() {
        opened = true;
        coroutine = openBox();
        StartCoroutine(coroutine);
    }

    private void Update() {
        if (opened) return;
        if (PianoKey.correct) open();
    }
}
