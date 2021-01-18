using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackWater : MonoBehaviour {

    public GameObject paper;
    public Text paperText;
    public Material blackWaterMat;
    public string password;
    public bool flag = false;

    public void put() {
        if (flag) return;
        flag = true;
        paper.layer = 0;
        paperText.text = password;
        ItemGUI.updateItemList(Item.selectedItemIndex);
        ItemGUI.resetSelected();
    }
}