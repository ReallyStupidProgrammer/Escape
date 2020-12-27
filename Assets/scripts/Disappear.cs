using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disappear : MonoBehaviour
{
    public void Open() {
        
        //if (OnMouseDown() && (true)) {
            Destroy(this.gameObject);
        //}
    }
}
