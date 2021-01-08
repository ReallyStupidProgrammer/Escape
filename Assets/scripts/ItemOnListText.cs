using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemOnListText : MonoBehaviour {

    private GameObject parentObject;

    private void Start() {
        parentObject = gameObject.transform.parent.gameObject;
    }

    private void Update() {
        string itemName = parentObject.GetComponent<ItemOnList>().itemName;
        if (itemName != "") {
            gameObject.GetComponent<Text>().text = itemName;
        }
    }
}
