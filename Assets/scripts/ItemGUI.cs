using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGUI : MonoBehaviour {

    public GameObject buttonPrefab;
    public static int lastItemIndex;
    public static List<GameObject> itemList;

    private void Start() {
        lastItemIndex = 0;
        itemList = new List<GameObject>();
        for (int i = 0; i < 10; i ++) {
            GameObject temp = Instantiate(buttonPrefab,
                                          gameObject.transform,
                                          false);
            RectTransform objectRect = temp.GetComponent<RectTransform>();
            objectRect.anchorMin = new Vector2((i % 2 == 0) ? 0 : 0.6f, 0.8f - ((int) i / 2) * 0.2f);
            objectRect.anchorMax = new Vector2((i % 2 == 0) ? 0.4f : 1, 1 - ((int) i / 2) * 0.2f);
            temp.GetComponent<ItemOnList>().index = i;
            itemList.Add(temp);
        }
        print(itemList[0]);
    }

    public static void updateItemList(int index) {
        for (int i = index; i < lastItemIndex; i ++) {
            itemList[i].GetComponent<ItemOnList>().picture = itemList[i + 1].GetComponent<ItemOnList>().picture;
            itemList[i].GetComponent<ItemOnList>().itemName = itemList[i + 1].GetComponent<ItemOnList>().itemName;
            itemList[i].GetComponent<ItemOnList>().objectName = itemList[i + 1].GetComponent<ItemOnList>().objectName;
            itemList[i].GetComponent<ItemOnList>().index = i;
        }
        lastItemIndex --;
    }

    public static void resetSelected() {
        Item.selectedItemIndex = -1;
        Item.selectedItemName = "";
    }
}
