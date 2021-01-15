using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cover : MonoBehaviour {

    public float origin;
    public static bool pwdCorrect = false;

    float transfer(float temp) {
        float ans = (temp + 360) % 360;
        if ((int) ans == 0 ) ans += 360;
        return ans;
    }

    public void open() {
        float mouseY = -Input.GetAxis("Mouse Y") * 3;
        float current = transform.localEulerAngles.z;
        if (transfer(current + mouseY) < transfer(origin - 90)) return;
        if (transfer(current + mouseY) > transfer(origin)) return;
        transform.Rotate(0, 0, mouseY, Space.Self);
    }

    private void Update() {
        if (gameObject.tag == "locked" && pwdCorrect)
            gameObject.tag = "unlocked";
    }
}
