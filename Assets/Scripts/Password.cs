﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Password : MonoBehaviour {
    
    public int index;
    public int[] correct;
    public int[] password;
    public GameObject dependentObject = null;
    public GameObject unlockItem = null;
    public bool whetherText = true;
    private bool whetherCorrect = false;

    private void textAdd() {
        Text pwd = gameObject.GetComponent<Text>();
        int num = int.Parse(pwd.text);
        num = (num + 1) % 10;
        pwd.text = num.ToString();
        if (unlockItem == null) unlockItem = gameObject.transform.parent.parent.gameObject;
        unlockItem.GetComponent<Password>().updatePassword(index, num);
    }

    private void imageAdd() {
        int num = gameObject.GetComponent<PasswordImage>().Add();
        if (unlockItem == null) unlockItem = gameObject.transform.parent.parent.gameObject;
        unlockItem.GetComponent<Password>().updatePassword(index, num);
    }

    public void add() {
        if (dependentObject != null && dependentObject.tag == "NoPower") return;
        if (whetherText) textAdd();
        else imageAdd();
    }

    private bool checkPwd() {
        for (int i = 0; i < correct.Length; i ++) {
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
