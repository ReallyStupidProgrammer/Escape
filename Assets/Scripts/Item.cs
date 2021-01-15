using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

    public static string selectedItemName = "";
    public static int selectedItemIndex = -1;
    public string objectName;
    public Sprite picture;
    public bool collected = false;
    public bool keepCollider = false;

    public static void changeLayer(GameObject current, int layerNum) {
        foreach (Transform child in current.GetComponentsInChildren<Transform>()) {
            child.gameObject.layer = layerNum;
        }
        current.layer = layerNum;
    }

    public void collect() {
        GameObject currentItem = ItemGUI.itemList[ItemGUI.lastItemIndex];
        currentItem.GetComponent<ItemOnList>().itemName = gameObject.name;
        currentItem.GetComponent<ItemOnList>().objectName = objectName;
        currentItem.GetComponent<ItemOnList>().picture = picture;
        ItemGUI.lastItemIndex ++;
        Item.changeLayer(gameObject, 8);      
        collected = true;
        if (!keepCollider) {
            Destroy(gameObject.GetComponent<BoxCollider>());
        } 
    }
}
