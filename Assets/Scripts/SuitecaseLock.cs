using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuitecaseLock : MonoBehaviour {

    public bool unlocked = false;
    private IEnumerator coroutine;
    private float speed = 1500;
    private float current = 180;

    private IEnumerator open() {
        while (current > 0) {
            current -= speed * Time.deltaTime;
            gameObject.transform.Rotate(0, 0, -speed * Time.deltaTime, Space.Self);
            yield return null;
        }
        StopCoroutine(coroutine);
    }

    public void unlock() {
        if (unlocked) return;
        unlocked = true;
        coroutine = open();
        StartCoroutine(coroutine);
    }
}
