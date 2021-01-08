using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

    public static string selectedItemName = "";
    public string objectName;

    public Sprite picture;

    public void collect() {
        GameObject currentItem = ItemGUI.itemList[ItemGUI.lastItemIndex];
        currentItem.GetComponent<ItemOnList>().itemName = gameObject.name;
        currentItem.GetComponent<ItemOnList>().picture = picture;
        ItemGUI.lastItemIndex ++;
        Destroy(gameObject);        
    }
}
