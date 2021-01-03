using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawer : MonoBehaviour
{
    IEnumerator coroutine = null;
    public static int[] password = {0, 0, 0};
    IEnumerator drag() {
        while (true) {
            if (Input.GetMouseButton(0)) {
                float mouseY = Input.GetAxis("Mouse Y") * 0.1f;
                if ((transform.localPosition.x >= -2.0 || mouseY > 0) 
                && (transform.localPosition.x <= 0 || mouseY < 0)) {
                    transform.Translate(mouseY, 0, 0, Space.Self);
                }
            }
            yield return null;
        }
    }
    bool check(string correct) {
        for (int i = 0; i < correct.Length; i ++) {
            if ((int) correct[i] - 48 != password[i]) 
                return false;
        }
        return true;
    }
    public void open(string correct) {
        if (gameObject.tag == "locked" && check(correct)) {
            gameObject.tag = "unlocked";    
        }
        if (gameObject.tag == "unlocked") {
            coroutine = drag();
            StartCoroutine(coroutine);
        }
    }

    public void stop() {
        if (coroutine != null) StopCoroutine(coroutine);
        coroutine = null;
    }

    public void open() {
        coroutine = drag();
        StartCoroutine(coroutine);
    }
}
