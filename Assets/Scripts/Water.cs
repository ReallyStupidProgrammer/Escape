using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour {

    public IEnumerator coroutine;
    public bool full = false;
    public GameObject switch1;
    public GameObject switch2;

    public bool invisible;

    private IEnumerator waterFlush(int upDown, float endPosition, float speed) {
        float currentPosition = gameObject.transform.localPosition.y;
        bool flag = (upDown > 0) ? (currentPosition < endPosition) : (currentPosition > endPosition);
        full = true;
        while (flag) {
            yield return null;
            if (!full) break;
            gameObject.transform.Translate(0, upDown * speed, 0, Space.World);
            currentPosition = gameObject.transform.localPosition.y;
            flag = (upDown > 0) ? (currentPosition < endPosition) : (currentPosition > endPosition);
        }
        StopCoroutine(coroutine);
    }

    public void waterMovement(int upDown, float endPosition, float speed) {
        coroutine = waterFlush(upDown, endPosition, speed);
        StartCoroutine(coroutine);
    }

    public void changeMat(Material newMat) {
        gameObject.GetComponent<MeshRenderer>().material = newMat;
    }

    private void Update() {
        if ((switch1 != null && !switch1.GetComponent<Switch>().state) 
        && (switch2 != null && !switch2.GetComponent<Switch>().state)) {
            full = false;
            if (invisible && gameObject.layer != 8) Item.changeLayer(gameObject, 8);
        } else if (invisible && gameObject.layer != 0) Item.changeLayer(gameObject, 0);
    }

}