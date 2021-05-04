using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour {

    public float origin;
    public float amount = 90;
    public bool reverse;
    public bool leftRight;
    public bool mouseXY = true;
    public GameObject relatedKey;
    public int speed = 3;
    public int xyz = 1;
    public bool world = true;

    float transfer(float temp, bool added) {
        float ans = (temp + 360) % 360;
        if ((int) ans == 0)
            if (added) ans += 360;
        return ans;
    }

    public void open() {
        string mouseName = (mouseXY) ? "Mouse X" : "Mouse Y";
        float mouse = Input.GetAxis(mouseName) * speed;
        float current;
        if (xyz == 0)
            current = transform.localEulerAngles.x;
        else if (xyz == 1)
            current = transform.localEulerAngles.y;
        else if (xyz == 2)
            current = transform.localEulerAngles.z;
        else return;
        if (reverse) {
            mouse *= -1;
        }
        if (leftRight) {
            if (transfer(current + mouse, false) > transfer(origin + amount, true)) return;
            if (transfer(current + mouse, false) < transfer(origin, false)) return;
        } else {
            if (transfer(current + mouse, false) < transfer(origin - amount, false)) return;
            if (transfer(current + mouse, false) > transfer(origin, true)) return;
        }
        if (world) {
            if (xyz == 0)
                transform.Rotate(mouse, 0, 0, Space.World);
            else if (xyz == 1)
                transform.Rotate(0, mouse, 0, Space.World);
            else if (xyz == 2)
                transform.Rotate(0, 0, mouse, Space.World);
        } else {
            if (xyz == 0)
                transform.Rotate(mouse, 0, 0, Space.Self);
            else if (xyz == 1)
                transform.Rotate(0, mouse, 0, Space.Self);
            else if (xyz == 2)
                transform.Rotate(0, 0, mouse, Space.Self);
        }
        
    }
}
