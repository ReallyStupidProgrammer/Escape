using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour {

    public GameObject[] switchFlush;
    public GameObject[] switchAdd;
    public bool invisibleOrMove;
    public float upPosition;
    public float downPosition;
    public float speed;

    public void changeMat(Material newMat) {
        gameObject.GetComponent<MeshRenderer>().material = newMat;
    }

    private int checkSwitch() {
        int ans = 0;
        for (int i = 0; i < switchAdd.Length; i ++) {
            if (switchAdd[i].GetComponent<Switch>().state) {
                ans += 1;
                break;
            }
        }
        for (int i = 0; i < switchFlush.Length; i ++) {
            if (switchFlush[i].GetComponent<Switch>().state) {
                ans -= 1;
                break;
            }
        }
        return ans;
    }

    private void Update() {
        int upDown = checkSwitch();
        bool checkSound = (gameObject.GetComponent<WaterSound>() != null);
        if (invisibleOrMove) {
            if (upDown > 0 && gameObject.layer == 8) {
                if (checkSound) gameObject.GetComponent<WaterSound>().playSound();
                Item.changeLayer(gameObject, 0);
            } else if (upDown == 0 && gameObject.layer == 0) {
                if (checkSound) gameObject.GetComponent<WaterSound>().stopPlay();
                Item.changeLayer(gameObject, 8);
            }
        } else {
            float currentPosition = gameObject.transform.localPosition.y;

            if (checkSound)
                if (upDown < 0 && currentPosition > downPosition) gameObject.GetComponent<WaterSound>().playSound();
                else gameObject.GetComponent<WaterSound>().stopPlay();

            if (upDown > 0 && currentPosition < upPosition) {
                gameObject.transform.Translate(0, upDown * speed * Time.deltaTime, 0, Space.World);
            } 
            if (upDown < 0 && currentPosition > downPosition) {
                gameObject.transform.Translate(0, upDown * speed * Time.deltaTime, 0, Space.World);
            }
        }

    }

}