using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    public float origin;

    public void open() {
        float mouseX = Input.GetAxis("Mouse X") * 3;
        float current = transform.eulerAngles.y;
        if (current + mouseX > origin + 90) return;
        if (current + mouseX < origin) return;
        transform.Rotate(0, mouseX, 0, Space.World);
    }
}
