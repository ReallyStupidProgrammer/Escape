using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    IEnumerator coroutine = null;

    IEnumerator rotate(Quaternion origin) {
        while ((Quaternion.Angle(transform.localRotation, origin) < 90)) {
            //print(Quaternion.Angle(transform.localRotation, origin));
            yield return null;
            if (Input.GetMouseButton(0)) {
                float mouseX = Input.GetAxis("Mouse X") * 3;
                //print(transform.localRotation.y);
                //print(mouseX);
                transform.Rotate(0, mouseX, 0, Space.World);
            }
            if (Quaternion.Angle(transform.localRotation, origin) >= 90) {
                //print(transform.localRotation.y);
                gameObject.tag = "opened";
                Rigidbody current = transform.GetComponent<Rigidbody>();
                current.velocity = Vector3.zero;
                current.freezeRotation = true;
            }
        }
    }

    public void open() {
        if (gameObject.tag == "unlocked") {
            Quaternion origin = transform.localRotation;
            //print(origin);
            coroutine = rotate(origin);
            StartCoroutine(coroutine);
        }
    }

    public void stop() {
        if (coroutine != null) StopCoroutine(coroutine);
        coroutine = null;
    }

}
