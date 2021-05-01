using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Password : MonoBehaviour {
    
    public int index;
    public int[] correct;
    public int[] password;
    public bool power = true;
    private bool whetherCorrect = false;
    private GameObject item;

    public void add() {
        if (!power) return;
        Text pwd = gameObject.GetComponent<Text>();
        int num = int.Parse(pwd.text);
        num = (num + 1) % 10;
        pwd.text = num.ToString();
        item = gameObject.transform.parent.parent.gameObject;
        item.GetComponent<Password>().updatePassword(index, num);
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
