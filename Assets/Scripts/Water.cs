using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour {

    IEnumerator coroutine;

    public bool full = false;

    private IEnumerator waterFlush(int upDown, float endPosition, float speed) {
        float currentPosition = gameObject.transform.localPosition.y;
        bool flag = (upDown > 0) ? (currentPosition < endPosition) : (currentPosition > endPosition);
        while (flag) {
            yield return null;
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

}