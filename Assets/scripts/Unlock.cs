using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unlock : MonoBehaviour
{
    IEnumerator coroutine;

    public void unlock() {
        gameObject.tag = "unlocked";

    }

    IEnumerator message() {
        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);
    }

    public void showMessage() {
        if (gameObject.tag == "unshowed") {
            gameObject.SetActive(true);
            gameObject.tag = "showed";
            coroutine = message();
            StartCoroutine(coroutine);
        } 
    }
}
