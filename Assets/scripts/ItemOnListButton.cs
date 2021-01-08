using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemOnListButton : MonoBehaviour {

    private GameObject parentObject;

    private void Start() {
        parentObject = gameObject.transform.parent.gameObject;
    }

    public void onClicked() {
        string itemName = parentObject.GetComponent<ItemOnList>().itemName;
        if (Item.selectedItemName == itemName) 
            Item.selectedItemName = "";
        else 
            Item.selectedItemName = itemName;
    }

    private void Update() {
        Sprite picture = parentObject.GetComponent<ItemOnList>().picture;
        if (picture != null) {
            gameObject.GetComponent<Button>().image.sprite = picture;
        }
    }
    
}
