using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemOnListText : MonoBehaviour {

    private GameObject parentObject;

    private void Start() {
        parentObject = gameObject.transform.parent.gameObject;
    }

    private void Update() {
        string objectKey = parentObject.GetComponent<ItemOnList>().objectName;
        gameObject.GetComponent<Text>().text = Language.language[objectKey].str;
    }
}
