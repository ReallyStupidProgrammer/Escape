using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour {

    public float close;
    public float open;
    public bool state = false;

    public GameObject water;

    public GameObject waterCylinder;

    private void Update() {
        if (transform.localEulerAngles.y >= open - 1 && transform.localEulerAngles.y <= open + 1) {
            state = true;
            if (water != null && !water.GetComponent<Water>().full) {
                water.GetComponent<Water>().waterMovement(1, 23.5f, 0.0002f);
            }
        } else {
            state = false;
        }
    }
}
