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

    public void showMessage() {
        gameObject.SetActive(true);
        coroutine = message();
        StartCoroutine(coroutine);
    }

    private void Update() {
        print(Controller.message);
        if (gameObject.name == Controller.message) {
            showMessage();
        }
    }
}
