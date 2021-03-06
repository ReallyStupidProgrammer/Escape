﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlLight : MonoBehaviour {

    private void changeColor(Color currentColor) {
        gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", currentColor);
    }
    private void Update() {
        if (gameObject.name == "closetLight" && KeyHole.lightControl >= 2) {
            changeColor(Color.green);
            return;
        }
        if (gameObject.name == "computerLight" && KeyHole.lightControl >= 1) {
            changeColor(Color.green);
            return;
        }
        if (gameObject.name == "machineLight" && gameObject.transform.parent.gameObject.tag == "PowerOn") {
            changeColor(Color.green);
            return;
        }
        changeColor(Color.red);
    }
}
