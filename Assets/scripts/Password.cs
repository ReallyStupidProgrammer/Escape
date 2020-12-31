using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Password : MonoBehaviour
{
    public void add() {
        Text pwd = gameObject.GetComponent<Text>();
        int num = int.Parse(pwd.text);
        num = (num + 1) % 10;
        pwd.text = num.ToString();
    }
}
