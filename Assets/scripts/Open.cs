using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open : MonoBehaviour
{
    IEnumerator coroutine;

    IEnumerator rotate() {
        while (transform.localEulerAngles.y < 180) {
            yield return null;
            if (Input.GetMouseButton(0)) {
                float mouseX = Input.GetAxis("Mouse X") * 3;
                transform.Rotate(0, mouseX, 0, Space.World);
            }
        }
    }
    public void open() {
        if (gameObject.tag == "unlocked") {
            coroutine = rotate();
            StartCoroutine(coroutine);
        }
    }

}
