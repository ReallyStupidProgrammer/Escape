using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CD : MonoBehaviour {

    public GameObject relatedObject;
    public string objectName;
    public Sprite picture;

    private bool added = false;

    private void Update() {
        if (relatedObject == null) return;
        if (!added && relatedObject.GetComponent<Item>().collected) {
            added = true;
            gameObject.AddComponent<Item>();
            gameObject.GetComponent<Item>().objectName = objectName;
            gameObject.GetComponent<Item>().picture = picture;
            gameObject.tag = "item";
        }
    }
}
