using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour {

    public float origin;
    public bool reverse;
    public bool leftRight;
    public GameObject relatedKey;
    public int speed = 3;
    public int xyz = 1;

    float transfer(float temp, bool added) {
        float ans = (temp + 360) % 360;
        if ((int) ans == 0)
            if (added) ans += 360;
        return ans;
    }

    public void open() {
        float mouseX = Input.GetAxis("Mouse X") * speed;
        float current;
        if (xyz == 0)
            current = transform.localEulerAngles.x;
        else if (xyz == 1)
            current = transform.localEulerAngles.y;
        else if (xyz == 2)
            current = transform.localEulerAngles.z;
        else return;
        if (reverse) {
            mouseX *= -1;
        }
        print(current);
        if (leftRight) {
            if (transfer(current + mouseX, false) > transfer(origin + 90, true)) return;
            if (transfer(current + mouseX, false) < transfer(origin, false)) return;
        } else {
            if (transfer(current + mouseX, false) < transfer(origin - 90, false)) return;
            if (transfer(current + mouseX, false) > transfer(origin, true)) return;
        }
        if (xyz == 0)
            transform.Rotate(mouseX, 0, 0, Space.World);
        else if (xyz == 1)
            transform.Rotate(0, mouseX, 0, Space.World);
        else if (xyz == 2)
            transform.Rotate(0, 0, mouseX, Space.World);
        
    }
}
