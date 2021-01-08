using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {
    RaycastHit hit;
    GameObject current;
    public static string message = "";
    public static Color messageColor = Color.clear;

    bool getHit() {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        return Physics.Raycast((Ray) ray, out hit);
    }

    private void doorOperation(GameObject door) {
        if (door.tag == "locked") {
            GameObject key = door.GetComponent<Door>().relatedKey;
            string keyName;
            if (key == null) {
                keyName = "$$$";
            } else {
                keyName = key.name;
            }
            if (Item.selectedItemName != keyName) {
                message = "未解锁";
                messageColor = Color.red;
            } else {
                message = "已开锁";
                messageColor = Color.green;
                door.tag = "unlocked";
                ItemGUI.updateItemList(Item.selectedItemIndex);
                ItemGUI.resetSelected();
            }
        } else if (door.tag == "unlocked") {
            door.GetComponent<Door>().open();
        } 
    }

    private void drawerOperation(GameObject drawer) {
        if (drawer.tag == "unlocked") {
            drawer.GetComponent<Drawer>().open();
        }
    }

    private void pwdOperation(GameObject pwd) {
        pwd.GetComponent<Password>().add();
    }

    private void transmitOperation(GameObject transmition) {
        message = transmition.GetComponent<Transmit>().message;
        messageColor = Color.green;
        int upDown = transmition.GetComponent<Transmit>().upDown;
        transform.position = new Vector3(transform.position.x, 
                                         transform.position.y + upDown * 26, 
                                         transform.position.z);
    }

    private void computerOperation(GameObject computer) {
        if (computer.tag == "NoPower") {
            message = "未通电";
            messageColor = Color.red;
        }
    }
    
    private void keyHoleOperation(GameObject keyHole) {
        //if (KeyHole.lightControl < 2) KeyHole.lightControl += 1;
        if (keyHole.GetComponent<KeyHole>().key.name == Item.selectedItemName) {
            keyHole.GetComponent<KeyHole>().plugin();
            ItemGUI.updateItemList(Item.selectedItemIndex);
            ItemGUI.resetSelected();
        }
    }

    private void itemOperation(GameObject item) {
        if (item.GetComponent<Item>().collected) return;
        item.GetComponent<Item>().collect();
        message = "获得道具：" + item.GetComponent<Item>().objectName;
        messageColor = Color.green;
    }
    
    private void coverOperation(GameObject cover) {
        cover.GetComponent<Cover>().open();
    }

    private void screenOperation(GameObject screen) {
        if (Item.selectedItemName == screen.GetComponent<Screen>().relatedItem.name) {
            screen.GetComponent<Screen>().crash();

        }
        
    }

    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            if (!getHit()) return;
            current = hit.collider.gameObject;
        }
        if (current != null) {
            if (current.name.IndexOf("Door") >= 0) {
                doorOperation(current);
            } else if (current.name.IndexOf("drawer") >= 0) {
                drawerOperation(current);
            } else if (current.name.IndexOf("cover") >= 0) {
                coverOperation(current);
            }
        } else 
            return;
        if (Input.GetMouseButtonUp(0)) {
            if (current.name.IndexOf("Pwd") >= 0) {
                pwdOperation(current);
            } else if (current.name.IndexOf("Transmition") >= 0) {
                transmitOperation(current);
            } else if (current.name.IndexOf("computer") >= 0) {
                computerOperation(current);
            } else if (current.name.IndexOf("KeyHole") >= 0) {
                keyHoleOperation(current);
            } else if (current.tag == "item") {
                itemOperation(current);
            } else if (current.name.IndexOf("screen") >= 0) {
                screenOperation(current);
            }
            current = null;
        }

    }
}
