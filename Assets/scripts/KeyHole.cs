using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyHole : MonoBehaviour {

    public static int lightControl = 0;

    public GameObject key;

    private bool pluged = false;

    public void plugin() {
        if (pluged) return;
        GameObject newKey = Instantiate(key,
                                        new Vector3(-5.4614f, -26.7564f, 5.8428f),
                                        new Quaternion(0.9f, 0.0f, -0.4f, 0.0f));
        pluged = true;
        newKey.GetComponent<Item>().collected = true;
    }
}
