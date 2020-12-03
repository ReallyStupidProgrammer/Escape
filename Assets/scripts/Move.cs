using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {
    int Speed = 3;
    private CharacterController controller;

    void Start() {
        controller = gameObject.GetComponent<CharacterController>();
    }

    void MoveForward() {
        controller.Move(transform.forward * Time.deltaTime * Speed);
    }
    void MoveBack() { 
        controller.Move(transform.forward * Time.deltaTime * -Speed) ;
    }
    void MoveLeft() { 
        controller.Move(transform.right * Time.deltaTime * -Speed);
    }
    void MoveRight() {
        controller.Move(transform.right * Time.deltaTime * Speed);
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKey(KeyCode.W)) {
            MoveForward();
            Debug.Log("W");
        }
        if (Input.GetKey(KeyCode.A)) {
            MoveLeft();
            Debug.Log("A");
        }
        if (Input.GetKey(KeyCode.S)) {
            MoveBack();
            Debug.Log("S");
        }
        if (Input.GetKey(KeyCode.D)) {
            MoveRight();
            Debug.Log("D");
        }
        if (Input.GetMouseButton(1)) {
            float mouseX = Input.GetAxis("Mouse X") * 3;
            transform.Rotate(0, mouseX, 0, Space.World);
        }
    }
}
