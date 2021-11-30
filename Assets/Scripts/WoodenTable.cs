using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodenTable : MonoBehaviour {

    public GameObject slideLeftDoor = null;
    public GameObject slideRightDoor = null;
    public GameObject platform = null;
    public GameObject motorSound = null;
    public float maxDoorAmount = 0;
    public float maxPlatformAmount = 0;
    private bool opened = false;
    private IEnumerator coroutine;
    private float doorSpeed = 0.5f;
    private float platformSpeed = 0.2f;
    private float leftDoorAmount = 0;
    private float platformAmount = 0;

    private IEnumerator move() {
        motorSound.GetComponent<Sounds>().playSound(0);
        while (true) {
            bool flag = true;
            if (leftDoorAmount + doorSpeed * Time.deltaTime < maxDoorAmount) {
                slideLeftDoor.transform.Translate(0, 0, doorSpeed * Time.deltaTime, Space.Self);
                slideRightDoor.transform.Translate(0, 0, -doorSpeed * Time.deltaTime, Space.Self);
                leftDoorAmount += doorSpeed * Time.deltaTime;
                flag = false;
            }        
            if (platformAmount + platformSpeed * Time.deltaTime < maxPlatformAmount) {
                platform.transform.Translate(0, platformSpeed * Time.deltaTime, 0, Space.Self);
                platformAmount += platformSpeed * Time.deltaTime;
                flag = false;
            }
            if (flag) break;
            yield return null;
        }
        StopCoroutine(coroutine);
        motorSound.GetComponent<Sounds>().stopPlay();
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