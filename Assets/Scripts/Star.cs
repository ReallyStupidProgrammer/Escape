using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour {

    public GameObject[] corns = {null, null, null, null};
    public GameObject middle;
    public GameObject[] balls = {null, null, null, null};
    public string[] correctNames = {"", "", "", ""};
    public GameObject woodenTable = null;
    private int[] checkSum = {0, 0, 0, 0};

    private static void changeEmissionColor(GameObject obj, Color color) {
        obj.GetComponent<Renderer>().material.SetColor("_EmissionColor", color);
        obj.GetComponent<Renderer>().material.SetColor("_Color", (color == Color.red) ? Color.white : color);
    }

    private void Start() {
        changeEmissionColor(middle, Color.red);
        changeEmissionColor(corns[0], Color.red);
        changeEmissionColor(corns[1], Color.red);
        changeEmissionColor(corns[2], Color.red);
        changeEmissionColor(corns[3], Color.red);
    }

    private void Update() {
        int count = 0;
        for (int i = 0; i < 4; i ++) {
            checkSum[i] = (balls[i].name == correctNames[i]) ? 1 : 0;
            changeEmissionColor(corns[i], (checkSum[i] == 1) ? Ball.ballColor[correctNames[i]] : Color.red);
            count += checkSum[i];
        }
        changeEmissionColor(middle, (count == 4) ? Color.green : Color.red);
        woodenTable.tag = (count == 4) ? "locked" : "NoPower";
    }
}