using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallControlBoxDoor : MonoBehaviour {

    private IEnumerator coroutine;
    private float currentAngle = 0;
    private float speed = 0.03f;
    private float maxAngle = 180;

    private IEnumerator rotate() {
        while (currentAngle < maxAngle) {
            gameObject.transform.Rotate(0, 0, speed, Space.Self);
            currentAngle += speed;
            yield return null;
        }
        StopCoroutine(coroutine);
    }

    public void open() {
        coroutine = rotate();
        StartCoroutine(coroutine);
    }
}