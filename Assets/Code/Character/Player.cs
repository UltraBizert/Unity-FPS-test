using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    public float MoveSpeed = 1;
    public float RotationSpeed = 1;
    private Vector2 moveInput;

    void Update ()
    {
        GetInputs();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void GetInputs()
    {
        moveInput.x = CrossPlatformInputManager.GetAxis("Horizontal");
        moveInput.y = CrossPlatformInputManager.GetAxis("Vertical");
    }

    private void Move()
    {
        transform.Translate(0, 0, moveInput.y * MoveSpeed);
        transform.Rotate(0, moveInput.x * RotationSpeed, 0);
    }
}
