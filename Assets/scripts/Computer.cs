using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Computer : MonoBehaviour {
    private Text currentText;

    private void Update() {
        if (gameObject.name == "Text") {
            currentText = gameObject.GetComponent<Text>();
            if (gameObject.transform.parent.parent.gameObject.tag == "PowerOn") {
                currentText.text = "3  7  4";
            } else {
                currentText.text = "";
            }
        }
        if (gameObject.name.IndexOf("Cube") >= 0) {
            GameObject parent = gameObject.transform.parent.gameObject;
            if (parent.tag == "Broken") Destroy(gameObject);
        }
        if (gameObject.name.IndexOf("computer") >= 0) {
            if (KeyHole.lightControl >= 1 && gameObject.tag == "NoPower") 
                gameObject.tag = "PowerOn";
        }
    }
}
