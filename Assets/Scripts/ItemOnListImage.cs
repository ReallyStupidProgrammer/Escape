using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemOnListImage : MonoBehaviour {

    private GameObject parentObject;
    private Color defaultColor;

    private void Start() {
        parentObject = gameObject.transform.parent.parent.gameObject;
        defaultColor = Color.white;
        defaultColor.a = 0.5f;    
    }

    private void Update() {
        Sprite picture = parentObject.GetComponent<ItemOnList>().picture;
        if (picture != null) {
            gameObject.GetComponent<Image>().sprite = picture;
            gameObject.GetComponent<Image>().color = Color.white;
        } else {
            gameObject.GetComponent<Image>().sprite = null;
            gameObject.GetComponent<Image>().color = defaultColor;
        }
    }
}
