using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour {

    public float origin;
    public bool reverse;

    public bool leftRight;

    public GameObject relatedKey;

    public int speed = 3;

    float transfer(float temp, bool added) {
        float ans = (temp + 360) % 360;
        if ((int) ans == 0)
            if (added) ans += 360;
        return ans;
    }

    public void open() {
        float mouseX = Input.GetAxis("Mouse X") * speed;
        float current = transform.localEulerAngles.y;
        if (reverse) {
            mouseX *= -1;
        }
        if (leftRight) {
            if (transfer(current + mouseX, false) > transfer(origin + 90, true)) return;
            if (transfer(current + mouseX, false) < transfer(origin, false)) return;
        } else {
            if (transfer(current + mouseX, false) < transfer(origin - 90, false)) return;
            if (transfer(current + mouseX, false) > transfer(origin, true)) return;
        }
        transform.Rotate(0, mouseX, 0, Space.World);
    }
}
