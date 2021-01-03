using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    RaycastHit hit;
    GameObject current;
    public static string message = "";

    bool getHit() {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        return Physics.Raycast((Ray) ray, out hit);
    }

    //Control the door operations.
    private void doorOperation(GameObject door) {
        if (door.tag == "locked") {
            message = "noKey";
            //GUI.Label(new Rect(500, 500, 50, 50), "缺少钥匙");
        } else if (door.tag == "keyFound") {
            //print("test1");
            door.tag = "unlocked";
        } else if (door.tag == "unlocked" && Input.GetMouseButton(0)) {
            //print("test1");
            door.GetComponent<Door>().open();
        }
    }
    
    // Update is called once per frame
    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            if (!getHit()) return;
            current = hit.collider.gameObject;
        }
        if (Input.GetMouseButtonUp(0)) {
            current = null;
        }
        if (current != null) {
            if (current.name.IndexOf("Door") > 0) {
                doorOperation(current);
            }
        }

    }
}
