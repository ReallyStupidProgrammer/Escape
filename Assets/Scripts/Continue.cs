using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Continue : MonoBehaviour {

    private void Update() {
        if (GameLoading.saved) {
            gameObject.GetComponent<Button>().enabled = true;
            gameObject.GetComponent<Image>().color = Color.white;
        } else {
            gameObject.GetComponent<Button>().enabled = false;
            gameObject.GetComponent<Image>().color = Color.grey;
        }
    }
}