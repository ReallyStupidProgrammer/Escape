using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyRotate : MonoBehaviour {

    private RaycastHit hit;
    private double pre = 360;
    private bool flag = false;

    private bool getHit() {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        return Physics.Raycast((Ray) ray, out hit);
    }

    private float dist(float a, float b, float c, float d) {
        return (float) Math.Pow((Math.Pow((a - c), 2) + Math.Pow((b - d), 2)), 0.5);
    }

    public void rotate() {
        getHit();
        float mouseX = hit.point.x;
        float mouseY = hit.point.y;
        float keyX = gameObject.transform.position.x;
        float keyY = gameObject.transform.position.y;
        float d = dist(mouseX, mouseY, keyX, keyY);
        if (d < 0.05) return;
        double newAngle = System.Math.Atan2((double) (mouseX - keyX), (double) (mouseY - keyY)) * (180 / System.Math.PI);
        if (newAngle < 0) newAngle += 360;
        if (newAngle <= 1) {
            if (!flag) {
                if (pre < 90 && KeyHole.lightControl < 2) KeyHole.lightControl += 1;
                else if (pre > 90 && KeyHole.lightControl > 0) KeyHole.lightControl -= 1;
            }
            flag = true;
        } else {
            flag = false;
        }
        gameObject.transform.eulerAngles = new Vector3(360f - (float) newAngle, 227.9f, 180.0f);
        pre = newAngle;
    }
}
