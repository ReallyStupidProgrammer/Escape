using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nail : MonoBehaviour {
 
    public GameObject pipe;
    public bool removed = false;
    
    public void removeNail() {
        if (Item.selectedItemName == "screwdriver") {
            pipe.GetComponent<Pipe>().nails -= 1;
            if (pipe.GetComponent<Pipe>().nails == 0) {
                ItemGUI.updateItemList(Item.selectedItemIndex);
                ItemGUI.resetSelected();
            }
            Destroy(gameObject);
        }

    }
}
