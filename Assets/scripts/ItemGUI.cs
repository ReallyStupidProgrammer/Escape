using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGUI : MonoBehaviour {

    public GameObject buttonPrefab;

    public static int lastItemIndex = 0;

    public static List<GameObject> itemList = new List<GameObject>();

    private void Start() {
        for (int i = 0; i < 10; i ++) {
            GameObject temp = Instantiate(buttonPrefab,
                                          gameObject.transform,
                                          false);
            RectTransform objectRect = temp.GetComponent<RectTransform>();
            objectRect.anchorMin = new Vector2((i % 2 == 0) ? 0 : 0.6f, 0.8f - ((int) i / 2) * 0.2f);
            objectRect.anchorMax = new Vector2((i % 2 == 0) ? 0.4f : 1, 1 - ((int) i / 2) * 0.2f);
            itemList.Add(temp);
        }
    }

    private void Update() {

    }
}
