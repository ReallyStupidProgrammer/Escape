using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallControlBoxDoor : MonoBehaviour {

    private IEnumerator coroutine;
    private float currentAngle = 0;
    private float speed = 10f;
    private float maxAngle = 180;

    private IEnumerator rotate() {
        while (currentAngle < maxAngle) {
            gameObject.transform.Rotate(0, 0, speed * Time.deltaTime, Space.Self);
            currentAngle += speed * Time.deltaTime;
            yield return null;
        }
        StopCoroutine(coroutine);
    }

    public void open() {
        coroutine = rotate();
        StartCoroutine(coroutine);
    }
}