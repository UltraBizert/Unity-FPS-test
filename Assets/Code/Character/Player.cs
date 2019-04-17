using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : HitEntity
{
    public float MoveSpeedForward = 1;
    public float MoveSpeedSide = 1;
    public float RotationSpeed = 1;

    private Vector2 moveInput;
    private float rotation;
    private Camera Camera;

    private void Awake()
    {
        Camera = GetComponentInChildren<Camera>();
    }

    void Update()
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
        var cDir = Camera.transform.forward;
        var dir = new Vector3(cDir.z, 0, -cDir.x).normalized;
        var sideDir = new Vector3(cDir.x, 0, cDir.z).normalized;

        var fwd = dir * moveInput.x;
        var side = sideDir * moveInput.y;

        var step = fwd + side;
        transform.position = Vector3.Lerp(transform.position, transform.position + step, Time.fixedDeltaTime * 100);
        transform.Rotate(0, rotation * RotationSpeed, 0);
    }
}