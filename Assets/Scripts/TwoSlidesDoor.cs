using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoSlidesDoor : MonoBehaviour {

    GameObject parentObject;
    
    private void Update() {
        parentObject = gameObject.transform.parent.gameObject;
        if (parentObject.tag == "unlocked") {
            gameObject.tag = "unlocked";
        }
        if (gameObject.tag == "unlocked") {
            parentObject.tag = "unlocked";
        }
    }
}
