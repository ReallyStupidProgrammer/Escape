using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    public float origin;
    public bool reverse;

    public bool leftRight;

    float transfer(float temp) {
        return (temp + 360) % 360;
    }

    public void open() {
        float mouseX = Input.GetAxis("Mouse X") * 3;
        float current = transform.localEulerAngles.y;
        if (reverse) {
            mouseX *= -1;
        }
            //print(mouseX);
            // print(current);

         //else {
        if (leftRight) {
            if (transfer(current + mouseX) > transfer(origin + 90)) return;
            if (transfer(current + mouseX) < origin) return;
        } else {
            if (transfer(current + mouseX) < transfer(origin - 90)) return;
            if (transfer(current + mouseX) > origin) return;
        }
        // }

        transform.Rotate(0, mouseX, 0, Space.World);
    }
}
