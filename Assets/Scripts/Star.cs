using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour {

    public GameObject purpleCorn;
    public GameObject blueCorn;
    public GameObject cyanCorn;
    public GameObject yellowCorn;
    public GameObject middle;

    private void Start() {
        middle.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.red);
        purpleCorn.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.red);
        blueCorn.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.red);
        cyanCorn.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.red);
        yellowCorn.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.red);
    }
}