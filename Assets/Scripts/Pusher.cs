using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pusher : MonoBehaviour {

    public float minAngle;
    public float maxAngle;
    public float speed = 3;

    public void push() {
        float mouse = Input.GetAxis("Mouse Y") * speed;
        float current = gameObject.transform.localEulerAngles.x;
        if (minAngle < 0 && current > minAngle + 360) current -= 360;
        if (current + mouse > minAngle && current + mouse < maxAngle) {
            gameObject.transform.Rotate(0, mouse, 0, Space.Self);
        }
        print(current + mouse);
    }
}