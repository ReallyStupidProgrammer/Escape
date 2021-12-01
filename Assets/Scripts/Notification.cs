using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notification : MonoBehaviour {

    public bool flag;
    public GameObject notification;
    public GameObject transmittion = null;
    public GameObject transmitSound;

    public void onClick() {
        if (flag) {
            transmitSound.GetComponent<Sounds>().playSound(0);
            transmittion.GetComponent<Transmit>().transmit();
        }
        notification.SetActive(false);
    }
}
