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

    //Control the door operations.
    private void doorOperation(GameObject door) {
        if (door.tag == "locked") {
            message = "缺少钥匙";
            messageColor = Color.red;
        } else if (door.tag == "keyFound") {
            message = "已开锁";
            messageColor = Color.green;
            if (Input.GetMouseButtonUp(0)) door.tag = "unlocked";
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
    
    // Update is called once per frame
    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            if (!getHit()) return;
            current = hit.collider.gameObject;
        }
        if (current != null) {
            print(current.name);
            if (current.name.IndexOf("Door") >= 0) {
                doorOperation(current);
            } else if (current.name.IndexOf("drawer") >= 0) {
                drawerOperation(current);
            }
        }
        if (Input.GetMouseButtonUp(0)) {
            if (current.name.IndexOf("Pwd") >= 0) {
                pwdOperation(current);
            }
            current = null;
        }

    }
}
