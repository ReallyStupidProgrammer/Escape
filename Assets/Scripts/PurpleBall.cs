using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleBall : MonoBehaviour {

    public GameObject basin;
    private bool dropped = false;

    private void Update() {
        if (dropped) return;
        if (basin.layer == 0) {
            dropped = true;
            gameObject.GetComponent<Rigidbody>().useGravity = true;
        }
    }
}