using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour {

    public GameObject CD;

    private bool flag = false;

    public void putCD() {
        if (flag) return;
        GameObject newCD = Instantiate(CD,
                                       new Vector3(5.033f, -1.991f, -4.63f),
                                       new Quaternion(0, 0, 0, 0));
        flag = true;
    }
}
