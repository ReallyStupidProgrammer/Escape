using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screen : MonoBehaviour {

    public GameObject relatedItem;

    public void crash() {
        Destroy(gameObject);
    }
}
