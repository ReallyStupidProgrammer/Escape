using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Password : MonoBehaviour
{
    public int index;
    private GameObject item; 
    public void add() {
        Text pwd = gameObject.GetComponent<Text>();
        int num = int.Parse(pwd.text);
        num = (num + 1) % 10;
        pwd.text = num.ToString();
        item = gameObject.transform.parent.parent.gameObject;
        item.GetComponent<Drawer>().updatePassword(index, num);
    }
}
