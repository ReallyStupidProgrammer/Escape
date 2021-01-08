using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemOnList : MonoBehaviour {

    public Sprite picture = null;

    public string itemName = "";

    public string objectName = "";

    private void Update() {
        if (itemName == "") return;
        if (itemName == Item.selectedItemName) {
            gameObject.GetComponentInChildren<Button>().image.color = Color.yellow;
        } else {
            gameObject.GetComponentInChildren<Button>().image.color = Color.white;
        }
    }

}
