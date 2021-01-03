using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{

    // Update is called once per frame
    public static Vector3 getHit() {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast((Ray) ray, out hit)) {
            return hit.point;
        }
        return Vector3.zero;
    }
}
