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
        int itemIndex = parentObject.GetComponent<ItemOnList>().index;
        if (Item.selectedItemName == itemName) {
            Item.selectedItemName = "";
            Item.selectedItemIndex = -1;
        } else { 
            Item.selectedItemName = itemName;
            Item.selectedItemIndex = itemIndex;
        }
    }

    private void Update() {
        Sprite picture = parentObject.GetComponent<ItemOnList>().picture;
        gameObject.GetComponent<Button>().image.sprite = picture;
    }
    
}
