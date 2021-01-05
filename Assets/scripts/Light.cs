using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light : MonoBehaviour {

    private void changeGreen() {
        gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.green);
    }
    private void Update() {
        if (gameObject.name == "closetLight" && KeyHole.lightControl >= 2) 
            changeGreen();
        if (gameObject.name == "computerLight" && KeyHole.lightControl >= 1) 
            changeGreen();
    }
}
