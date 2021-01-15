using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Message : MonoBehaviour {

    private IEnumerator coroutine;
    private Text currentText;
    private bool started = false;

    IEnumerator message() {
        currentText.text = Controller.message;
        currentText.color = Controller.messageColor;
        yield return new WaitForSeconds(1);
        currentText.text = "";
        started = false;
        Controller.message = "";
        StopCoroutine(coroutine);
    }
    public void showMessage() {
        if (started) return;
        coroutine = message();
        started = true;
        StartCoroutine(coroutine);
    }

    private void Update() {
        if (Controller.message == "") return;
        currentText = gameObject.GetComponent<Text>();
        showMessage();
    }
}
