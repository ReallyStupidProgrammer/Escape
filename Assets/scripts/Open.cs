using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open : MonoBehaviour
{
    int angle = 0;
    IEnumerator coroutine;

    IEnumerator rotate() {
        int angle = 0;
        while (angle < 90) {
            yield return null;
            transform.Rotate(0, 1, 0);
            angle += 1;
        }
    }
    public void open() {
        coroutine = rotate();
        StartCoroutine(coroutine);
    }
}
