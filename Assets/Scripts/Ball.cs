﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public static Dictionary<string, Color> ballColor = new Dictionary<string, Color>();

    private void put() {
        GameObject currentObject = ItemGUI.itemList[Item.selectedItemIndex];
        gameObject.GetComponent<Item>().objectName = currentObject.GetComponent<ItemOnList>().objectName;
        gameObject.GetComponent<Item>().picture = currentObject.GetComponent<ItemOnList>().picture;
        gameObject.name = currentObject.GetComponent<ItemOnList>().itemName;
        gameObject.GetComponent<Renderer>().material.SetColor("_Color", ballColor[gameObject.name]);
        ItemGUI.updateItemList(Item.selectedItemIndex);
        ItemGUI.resetSelected();
        Item.changeLayer(gameObject, 0);
        print("test");
    }

    public void operation() {
        if (gameObject.layer == 8 && Item.selectedItemIndex != -1) {
            put();
        } else if (gameObject.layer == 0) {
            gameObject.GetComponent<Item>().collect();
            print("test1");
        }
    }
}