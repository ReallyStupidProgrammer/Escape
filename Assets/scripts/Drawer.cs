using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawer : MonoBehaviour
{
    public int[] correct;

    public float origin;

    private int[] password = {0, 0, 0};
    private bool whetherCorrect = false;

    public void open() {
        float mouseY = Input.GetAxis("Mouse Y") * 0.1f;
        if ((transform.localPosition.x >= origin - 2.0f || mouseY > 0) 
        && (transform.localPosition.x <= origin || mouseY < 0)) {
            print("test");
            transform.Translate(mouseY, 0, 0, Space.Self);
        }
    }

    private bool checkPwd() {
        for (int i = 0; i < 3; i ++) {
            if (password[i] != correct[i]) return false;
        }
        return true;
    }

    private void Update() {
        if (gameObject.tag == "locked") {
            if (whetherCorrect) {
                gameObject.tag = "unlocked";
            }
        }    
    }

    public void updatePassword(int index, int num) {
        password[index] = num;
        whetherCorrect = checkPwd();
    }
}
