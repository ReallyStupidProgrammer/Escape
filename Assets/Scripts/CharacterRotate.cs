using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRotate : MonoBehaviour {

    void Update() {
        if (Input.GetMouseButton(1)) {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            float mouseY = Input.GetAxis("Mouse Y") * 2;
            float current = transform.localEulerAngles.x;
            if (current > 300) current -= 360;
            if (current - mouseY < -30 || current - mouseY > 30) return;
            transform.Rotate(-mouseY, 0, 0, Space.Self);
        }
        else {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
