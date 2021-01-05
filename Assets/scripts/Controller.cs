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
            message = "未解锁";
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

    private void transmitOperation(GameObject transmition) {
        message = transmition.GetComponent<Transmit>().getMessage();
        messageColor = Color.green;
        int upDown = transmition.GetComponent<Transmit>().getUpDown();
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
        if (KeyHole.lightControl < 2) KeyHole.lightControl += 1;
        print(KeyHole.lightControl);
    }

    // Update is called once per frame
    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            if (!getHit()) return;
            current = hit.collider.gameObject;
        }
        if (current != null) {
            //print(current.name);
            if (current.name.IndexOf("Door") >= 0) {
                doorOperation(current);
            } else if (current.name.IndexOf("drawer") >= 0) {
                drawerOperation(current);
            } 
        }
        if (Input.GetMouseButtonUp(0)) {
            if (current.name.IndexOf("Pwd") >= 0) {
                pwdOperation(current);
            } else if (current.name.IndexOf("Transmition") >= 0) {
                transmitOperation(current);
            } else if (current.name.IndexOf("computer") >= 0) {
                computerOperation(current);
            } else if (current.name.IndexOf("KeyHole") >= 0) {
                keyHoleOperation(current);
            }
            current = null;
        }

    }
}
