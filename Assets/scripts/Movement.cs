using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public bool positive;
    public int xyz;
    public bool mouseXY;
    public float length;
    public float origin;
    public float speed;
    public bool reverse;

    public void move() {
        float mouse;
        if (mouseXY) 
            mouse = Input.GetAxis("Mouse X") * speed;
        else 
            mouse = Input.GetAxis("Mouse Y") * speed;
        if (reverse) mouse *= -1;
        int temp = (positive) ? 1 : 0;
        if (xyz == 0) {
            if ((transform.localPosition.x >= origin + length * (temp - 1) || mouse > 0) 
            && (transform.localPosition.x <= origin + length * temp || mouse < 0)) {
                transform.Translate(mouse, 0, 0, Space.Self);
            }
        } else if (xyz == 1) {
            if ((transform.localPosition.y >= origin + length * (temp - 1) || mouse > 0) 
            && (transform.localPosition.y <= origin + length * temp || mouse < 0)) {
                transform.Translate(0, mouse, 0, Space.Self);
            }            
        } else if (xyz == 2) {
            if ((transform.localPosition.z >= origin + length * (temp - 1) || mouse > 0) 
            && (transform.localPosition.z <= origin + length * temp || mouse < 0)) {
                transform.Translate(0, 0, mouse, Space.Self);
            }            
        }
    }
}