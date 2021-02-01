using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notification : MonoBehaviour {

    public bool flag;
    public GameObject notification;
    public GameObject transmittion = null;

    public void onClick() {
        if (flag) {
            transmittion.GetComponent<Transmit>().transmit();
        }
        notification.SetActive(false);
    }
}
