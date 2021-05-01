using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodenTable : MonoBehaviour {

    public GameObject slideLeftDoor = null;
    public GameObject slideRightDoor = null;
    public GameObject platform = null;
    public float maxDoorAmount = 0;
    public float maxPlatformAmount = 0;
    private bool opened = false;
    private IEnumerator coroutine;
    private float doorSpeed = 0.0005f;
    private float platformSpeed = 0.0002f;
    private float leftDoorAmount = 0;
    private float platformAmount = 0;

    private IEnumerator move() {
        while (true) {
            bool flag = true;
            if (leftDoorAmount + doorSpeed < maxDoorAmount) {
                slideLeftDoor.transform.Translate(0, 0, doorSpeed, Space.Self);
                slideRightDoor.transform.Translate(0, 0, -doorSpeed, Space.Self);
                leftDoorAmount += doorSpeed;
                flag = false;
            }        
            if (platformAmount + platformSpeed < maxPlatformAmount) {
                platform.transform.Translate(0, platformSpeed, 0, Space.Self);
                platformAmount += platformSpeed;
                flag = false;
            }
            if (flag) break;
            yield return null;
        }
        StopCoroutine(coroutine);
    }

    private void open() {
        coroutine = move();
        StartCoroutine(coroutine);
    }

    private void Update() {
        if (gameObject.tag == "unlocked" && !opened) {
            opened = true;
            open();
        }
    }
}