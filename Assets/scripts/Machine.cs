using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machine : MonoBehaviour {

    public static bool machinePower = false;

    private void Update() {
        if (KeyHole.lightControl >= 2) {
            gameObject.tag = "PowerOn";
            machinePower = true;
        } else {
            gameObject.tag = "NoPower";
            machinePower = false;
        }
    }
}
