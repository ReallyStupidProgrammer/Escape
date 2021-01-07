using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGUI : MonoBehaviour {

    private void Start() {
        GUI.Button(new Rect(10, 10, 50, 50), "test");    
    }
}
