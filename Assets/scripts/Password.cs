using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Password : MonoBehaviour
{
    public void add(string item_name) {
        string item_tag = GameObject.Find(item_name).tag;
        if (item_tag == "locked") {
            Text pwd = gameObject.GetComponent<Text>();
            int num = int.Parse(pwd.text);
            num = (num + 1) % 10;
            pwd.text = num.ToString();
            Drawer.password[int.Parse(gameObject.name)] = num;
        }
    }
}
