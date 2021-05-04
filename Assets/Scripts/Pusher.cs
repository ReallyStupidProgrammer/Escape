using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pusher : MonoBehaviour {

    public float minAngle;
    public float maxAngle;
    public float speed = 3;
    public GameObject floor1Light;
    public GameObject floor2Light;
    public GameObject relatedWall;
    private int currentFloor = 1;

    private void wallMove(int upDown) {
        relatedWall.transform.Translate(0, upDown * 26, 0, Space.World);
    }

    public void push() {
        float mouse = Input.GetAxis("Mouse Y") * speed;
        float current = gameObject.transform.localEulerAngles.x;
        if (minAngle < 0 && current > minAngle + 360) current -= 360;
        if (current + mouse > minAngle && current + mouse < maxAngle) {
            gameObject.transform.Rotate(0, mouse, 0, Space.Self);
        }
        if (current > maxAngle - 5 && currentFloor == 2) {
            Star.changeEmissionColor(floor1Light, Color.red);
            Star.changeEmissionColor(floor2Light, Color.white);
            currentFloor = 1;
            wallMove(-1);
        }
        if (current < minAngle + 5 && currentFloor == 1) {
            Star.changeEmissionColor(floor1Light, Color.white);
            Star.changeEmissionColor(floor2Light, Color.red);
            currentFloor = 2;
            wallMove(1);
        }
        
    }
}