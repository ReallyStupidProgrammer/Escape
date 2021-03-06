﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour {

    public static bool pipeDestroyed;
    public GameObject CD;
    public int nails = 6;

    public bool CDPipe = false;

    private bool flag = false;

    public void putCD() {
        if (flag) return;
        GameObject newCD = Instantiate(CD,
                                       new Vector3(6.411f, -1.991f, -3.275f),
                                       new Quaternion(0, 0, 0, 0));
        flag = true;
    }

    public void removePipe() {
        if (nails == 0) {
            Destroy(gameObject);
            pipeDestroyed = true;
        }
    }
}
