using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour {

    public float close;
    public float open;
    public bool state = false;

    private void Update() {
        if (transform.localEulerAngles.y >= open - 1 && transform.localEulerAngles.y <= open + 1) {
            state = true;
        }
        state = false;
    }
}
