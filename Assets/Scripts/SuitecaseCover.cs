using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuitecaseCover : MonoBehaviour {

    public GameObject leftLock = null;
    public GameObject rightLock = null;

    private void Update() {
        if (gameObject.tag == "unlocked") return;
        bool left = leftLock.GetComponent<SuitecaseLock>().unlocked;
        bool right = rightLock.GetComponent<SuitecaseLock>().unlocked;   
        if (left & right) gameObject.tag = "unlocked";  
    }
}