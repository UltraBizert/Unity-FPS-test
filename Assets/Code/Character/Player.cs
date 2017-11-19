using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    public float MoveSpeedForward = 1;
    public float MoveSpeedSide = 1;
    public float RotationSpeed = 1;

    private Vector2 moveInput;
    private float rotation;

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
        rotation = CrossPlatformInputManager.GetAxis("Swipe");
    }

    private void Move()
    {
        transform.Translate(0, 0, moveInput.y * MoveSpeedForward);
        transform.Translate(moveInput.x * MoveSpeedSide, 0, 0);
        transform.Rotate(0, rotation * RotationSpeed, 0);
    }
}
