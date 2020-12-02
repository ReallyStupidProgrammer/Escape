using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {
    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButton(1)) {
            // float mouseX = Input.GetAxis("Mouse X") * 3;
            float mouseY = Input.GetAxis("Mouse Y") * 3;
            transform.Rotate(-mouseY, 0, 0, Space.Self);
            // transform.Rotate(0, mouseX, 0, Space.World);
            //transform.Rotate(0, mouseX, 0);
        }
    }
}
