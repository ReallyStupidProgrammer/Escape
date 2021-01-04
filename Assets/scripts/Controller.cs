using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
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
        } else if (door.tag == "unlocked" && Input.GetMouseButton(0)) {
            door.GetComponent<Door>().open();
        }
    }
    
    // Update is called once per frame
    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            if (!getHit()) return;
            current = hit.collider.gameObject;
        }
        if (current != null) {
            if (current.name.IndexOf("Door") > 0) {
                doorOperation(current);
            }
        }
        if (Input.GetMouseButtonUp(0)) {
            current = null;
        }

    }
}
