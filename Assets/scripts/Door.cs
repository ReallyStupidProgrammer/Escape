using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    IEnumerator coroutine;

    IEnumerator rotate(float origin) {
        while (transform.localEulerAngles.y < origin + 90) {
            yield return null;
            if (Input.GetMouseButton(0)) {
                float mouseX = Input.GetAxis("Mouse X") * 3;
                transform.Rotate(0, mouseX, 0, Space.Self);
            }
        }
    }

    public void open() {
        if (gameObject.tag == "unlocked") {
            gameObject.tag = "opened";
            float origin = transform.localEulerAngles.y;
            coroutine = rotate(origin);
            StartCoroutine(coroutine);
        }
    }

}
