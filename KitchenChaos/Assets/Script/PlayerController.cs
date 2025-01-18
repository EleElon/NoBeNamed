using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class PlayerController : MonoBehaviour {
    Vector3 move = Vector3.zero;
    float moveSpeed = 5f;
    float rotationSpeed = 10f;

    void Update() {
        HandleMovement();
    }

    void HandleMovement() {
        float x_Posi = Input.GetAxisRaw("Horizontal");
        float y_Posi = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(x_Posi, 0, y_Posi).normalized;

        Move(direction);

        transform.Translate(move * Time.deltaTime, Space.World);

        // Xoay player
        if (direction.magnitude > 0.1f) {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;

            Quaternion rotation = Quaternion.Euler(0, targetAngle, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);
        }
    }

    void Move(Vector3 direction) {
        if (direction.magnitude > 0) {
            move = direction * moveSpeed;
        }
        else {
            move = Vector3.zero;
        }
    }
}
