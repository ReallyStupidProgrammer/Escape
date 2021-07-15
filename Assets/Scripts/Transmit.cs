using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Transmit : MonoBehaviour
{
    
    public int upDown;
    public string message;
    public GameObject player;
    public GameObject notification;
    public GameObject yesButton;
    private bool flag = false;
    private float currentX;
    private float currentY;
    private float currentZ;

    private bool checkPosition() {
        //print(player.transform.position.z);
        if ((Mathf.Abs(player.transform.position.x - currentX) <= 1 
          && Mathf.Abs(player.transform.position.z - currentZ) <= 1)
          && Mathf.Abs(player.transform.position.y - currentY) <= 3) 
            return true;
        return false;
    }

    public void transmit() {
        Controller.message = Language.language["goto"].str + Language.language[message].str;
        Controller.messageColor = Color.green;
        // player.transform.position = new Vector3(player.transform.position.x, 
        //                                         player.transform.position.y + upDown * 26, 
        //                                         player.transform.position.z);
        CharacterMove.height += upDown * 26;
    }

    private void Start() {
        currentX = transform.position.x;
        currentY = transform.position.y;
        currentZ = transform.position.z;
    }
    private void Update() {
        if (checkPosition()) {
            if (flag) return;
            if (Controller.message != "") {
                flag = true;
                return;
            }
            flag = true;
            notification.SetActive(true);
            notification.GetComponentInChildren<Text>().text = Language.language["if"].str 
                                                             + Language.language[message].str
                                                             + "?";
            yesButton.GetComponent<Notification>().transmittion = gameObject;
        } else if (flag) {
            flag = false;
            notification.SetActive(false);
        }
    }
}
