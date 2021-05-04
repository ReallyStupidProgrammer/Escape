using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallControlBox : MonoBehaviour {

    public GameObject relatedDoor;

    public void open() {
        if (gameObject.tag != "unlocked") return;
        gameObject.GetComponent<Movement>().move();
        if (gameObject.transform.localPosition.y < gameObject.GetComponent<Movement>().origin) {
            Destroy(gameObject.GetComponent<BoxCollider>());
            relatedDoor.GetComponent<WallControlBoxDoor>().open();
        }
    }
}