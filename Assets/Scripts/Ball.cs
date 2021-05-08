using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public static Dictionary<string, Color> ballColor;
    public static Color purple;

    private void Start() {
        ballColor = new Dictionary<string, Color>();
        purple = new Color32(101, 0, 255, 255);
        try{
            Ball.ballColor.Add("yellowBall", Color.yellow);
            Ball.ballColor.Add("purpleBall", purple);
            Ball.ballColor.Add("cyanBall", Color.cyan);
            Ball.ballColor.Add("blueBall", Color.blue);
        } catch (System.ArgumentException) {
            ;
        }
    }

    private void put() {
        GameObject currentObject = ItemGUI.itemList[Item.selectedItemIndex];
        gameObject.GetComponent<Item>().objectName = currentObject.GetComponent<ItemOnList>().objectName;
        gameObject.GetComponent<Item>().picture = currentObject.GetComponent<ItemOnList>().picture;
        gameObject.name = currentObject.GetComponent<ItemOnList>().itemName;
        gameObject.GetComponent<Renderer>().material.SetColor("_Color", ballColor[gameObject.name]);
        ItemGUI.updateItemList(Item.selectedItemIndex);
        ItemGUI.resetSelected();
        Item.changeLayer(gameObject, 0);
    }

    public void operation() {
        if (gameObject.layer == 8 && Item.selectedItemIndex != -1) {
            put();
        } else if (gameObject.layer == 0) {
            gameObject.GetComponent<Item>().collect();
            gameObject.name = "invisible_" + gameObject.name;
        }
    }
}