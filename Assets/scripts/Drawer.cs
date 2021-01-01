using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawer : MonoBehaviour
{
    IEnumerator coroutine;

    IEnumerator drag(GameObject canvas) {
        while (true) {
            if (Input.GetMouseButton(0)) {
                float mouseY = Input.GetAxis("Mouse Y") * 0.1f;
                if (transform.localPosition.x <= -2.0 && mouseY < 0) ;
                else if (transform.localPosition.x >= 0 && mouseY > 0) ;
                else {
                    transform.Translate(mouseY, 0, 0, Space.Self);
                    canvas.transform.Translate(0, 0, mouseY, Space.Self);
                }
            }
            yield return null;
        }
    }
    public void open() {
        if (gameObject.tag == "unlocked") {
            GameObject canvas = GameObject.Find("closetCanvas");
            coroutine = drag(canvas);
            StartCoroutine(coroutine);
        }
    }
}
