using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open : MonoBehaviour
{
    IEnumerator coroutine;

    IEnumerator rotate() {
        print(transform.localEulerAngles);
        while (transform.localEulerAngles.y < 180) {
            yield return null;
            transform.Rotate(0, 1, 0);
        }
    }
    public void open() {
        coroutine = rotate();
        StartCoroutine(coroutine);
    }
}
