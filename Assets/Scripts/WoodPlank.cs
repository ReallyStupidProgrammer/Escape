using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodPlank : MonoBehaviour {

    public GameObject relatedWall = null;

    private void move(int upDown) {
        if (relatedWall != null && Machine.machinePower) relatedWall.transform.Translate(0, upDown * 26, 0, Space.World);
    }

    public void get() {
        gameObject.GetComponent<Item>().collect();
        move(-1);
    }

    public void put() {
        if (Item.selectedItemName == gameObject.name) {
            gameObject.layer = 0;
            ItemGUI.updateItemList(Item.selectedItemIndex);
            ItemGUI.resetSelected();
            move(1);
        }
    }
}
