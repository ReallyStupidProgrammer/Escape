using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoKey : MonoBehaviour {

    public static bool ControllerColliderHit = false;
    public static int[] correctPwd = {6, 8, 11, 8, 3, 4, 0};
    public static bool correct = false;
    public static int currentPos = 0;
    public int keyNum = 0;
    
    private IEnumerator coroutine;
    private float maxAngle = 5;
    private float speed = 100f;
    private float upDown = -1;
    private float currentAngle = 0;
    private bool moving = false;

    private IEnumerator keyDown() {
        while (true) {
            gameObject.transform.Rotate(speed * upDown * Time.deltaTime, 0, 0, Space.Self);
            currentAngle -= speed * upDown * Time.deltaTime;
            if (upDown == -1 && currentAngle >= maxAngle) {
                upDown = 1;
            }
            if (upDown == 1 && currentAngle <= 0) break;
            yield return null;
        }
        moving = false;
        currentAngle = 0;
        upDown = -1;
        gameObject.transform.localRotation = new Quaternion(0, 0, 0, 0);
        StopCoroutine(coroutine);
    }

    private void pianoKeyDown() {
        if (moving) return;
        currentAngle = 0;
        coroutine = keyDown();
        moving = true;
        StartCoroutine(coroutine);
    }

    public void push() {
        pianoKeyDown();
        if (correct) return;
        if (PianoKey.correctPwd[PianoKey.currentPos] == gameObject.GetComponent<PianoKey>().keyNum) {
            currentPos += 1;
        } else {
            currentPos = 0;
        }
        if (currentPos >= correctPwd.Length) correct = true;
    }
}