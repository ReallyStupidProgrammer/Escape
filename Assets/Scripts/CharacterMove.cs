using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour {
    public int Speed = 300000;
    private CharacterController controller;

    void Start() {
        controller = gameObject.GetComponent<CharacterController>();
    }

    void Update() {               
        if (Input.GetMouseButton(1)) {
            float mouseX = Input.GetAxis("Mouse X") * 3;
            transform.Rotate(0, mouseX, 0, Space.World);
        } else {
            var dir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            if (dir != Vector3.zero) 
                controller.Move(transform.rotation * dir * (Speed * Time.deltaTime));
        }
    }
}
