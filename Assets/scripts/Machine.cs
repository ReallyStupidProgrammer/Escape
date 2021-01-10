using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machine : MonoBehaviour {

    private void Update() {
        if (KeyHole.lightControl >= 2 && gameObject.tag == "NoPower") {
            gameObject.tag = "PowerOn";
        }
    }
}
