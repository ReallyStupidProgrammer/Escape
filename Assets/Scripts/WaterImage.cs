using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterImage : MonoBehaviour {
    
    public GameObject water;
    public float position;

    private void Update() {
        if (water.transform.position.y >= position) {
            gameObject.layer = 0;
        } else {
            gameObject.layer = 8;
        }
    }
}