using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawer : MonoBehaviour
{
    public void open() {
        if (Input.GetMouseButton(1)) {
            float mouseY = Input.GetAxis("mouseY") * 3;
            transform.Translate(mouseY, 0, 0, Space.Self);
        }
    }
}
