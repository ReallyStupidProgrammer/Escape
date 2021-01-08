using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

    public static string selectedItemName = "";
    public string objectName;

    public Sprite picture;

    public bool collected = false;

    private void changeLayer(int layerNum) {
        foreach (Transform child in gameObject.GetComponentsInChildren<Transform>()) {
            child.gameObject.layer = layerNum;
        }
        gameObject.layer = layerNum;
    }

    public void collect() {
        GameObject currentItem = ItemGUI.itemList[ItemGUI.lastItemIndex];
        currentItem.GetComponent<ItemOnList>().itemName = gameObject.name;
        currentItem.GetComponent<ItemOnList>().objectName = objectName;
        currentItem.GetComponent<ItemOnList>().picture = picture;
        ItemGUI.lastItemIndex ++;
        changeLayer(8);      
        collected = true; 
    }
}
