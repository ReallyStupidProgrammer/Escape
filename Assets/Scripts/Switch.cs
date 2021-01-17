using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour {

    public float open;
    public bool state = false;
    public bool rotate;
    public bool move;

    private void rotateSwitch() {
        if (transform.localEulerAngles.y >= open - 1 && transform.localEulerAngles.y <= open + 1) {
            state = true;
        } else {
            state = false;
        }
    }

    private void movementSwitch() {
        if (transform.localPosition.x >= open - 0.02f && transform.localPosition.x <= open + 0.02f) {
            state = true;
        } else {
            state = false;
        }
    }

    private void Update() {
        if (rotate) rotateSwitch();
        else if (move) movementSwitch();
    }
}
