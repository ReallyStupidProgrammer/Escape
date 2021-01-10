using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodBlank : MonoBehaviour {

    public void get() {
        gameObject.GetComponent<Item>().collect();
    }

    public void put() {
        if (Item.selectedItemName == gameObject.name) {
            gameObject.layer = 0;
            ItemGUI.updateItemList(Item.selectedItemIndex);
            ItemGUI.resetSelected();
        }
    }
}
