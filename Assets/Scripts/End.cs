using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour {

    public GameObject relatedDoor = null;
    public GameObject endLight = null;

    private void Update() {
        if (relatedDoor.tag == "unlocked") {
            endLight.SetActive(true);
        }
    }
}