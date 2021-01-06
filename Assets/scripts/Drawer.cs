using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawer : MonoBehaviour {
    public float origin;

    public void open() {
        float mouseY = Input.GetAxis("Mouse Y") * 0.1f;
        if ((transform.localPosition.x >= origin - 2.0f || mouseY > 0) 
        && (transform.localPosition.x <= origin || mouseY < 0)) {
            transform.Translate(mouseY, 0, 0, Space.Self);
        }
    }
}
