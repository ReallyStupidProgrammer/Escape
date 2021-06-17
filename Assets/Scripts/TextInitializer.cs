using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextInitializer : MonoBehaviour {

    public string key = "";
    private void Update() {
        if (key != "") {
            this.GetComponent<Text>().text = Language.language[key].str.Replace("\\n", "\n"); 
        }
    }
}
