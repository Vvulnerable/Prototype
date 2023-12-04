using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCharacterFacingController : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float rotationSpeed = 100.0f;
    private Vector3 velocity;

    void Update()
    {
        // Rotation
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);

        // Forward/Backward Movement
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 move = transform.forward * verticalInput;
        transform.Translate(move * moveSpeed * Time.deltaTime, Space.World);
    }
}