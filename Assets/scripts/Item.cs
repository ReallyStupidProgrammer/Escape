using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

    public string objectName;

    public Texture picture;

    public void collect() {
        Destroy(gameObject);        
    }
}
