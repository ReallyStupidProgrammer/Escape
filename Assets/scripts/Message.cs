using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Message : MonoBehaviour
{
    IEnumerator coroutine;

    IEnumerator message() {
        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);
    }

    bool check(string doorTag, string name) {
        return ((doorTag == "locked" && name == "noKey") || (doorTag == "keyFound" && name == "unlock"));
    }

    public void showMessage(string doorName) {
        if (doorName != "") {
            GameObject door = GameObject.Find(doorName);
            if (check(door.tag, gameObject.name)) {
                gameObject.SetActive(true);
                coroutine = message();
                StartCoroutine(coroutine);
                if (door.tag == "keyFound") {
                    door.tag = "unlocked";
                }
            }
        } else {
            gameObject.SetActive(true);
            coroutine = message();
            StartCoroutine(coroutine);
        }


    }
}
