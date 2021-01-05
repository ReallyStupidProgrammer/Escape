using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

    public string objectName;

    public string getName() {
        return objectName;
    }
    public void collect() {
        Destroy(gameObject);        
    }
}
