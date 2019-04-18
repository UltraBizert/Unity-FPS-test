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
        Camera = Camera.main;
        SetUpHealth();
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
        var cameraForward = Camera.transform.forward;
        var dir = new Vector3(cameraForward.z, 0, -cameraForward.x).normalized;
        var sideDir = new Vector3(cameraForward.x, 0, cameraForward.z).normalized;

        var forward = dir * moveInput.x * MoveSpeedForward;
        var side = sideDir * moveInput.y * MoveSpeedSide;

        var targetPosition = transform.position + forward + side;

        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.fixedDeltaTime);
        transform.Rotate(0, rotation * RotationSpeed, 0);
    }

    protected override void Die()
    {
        Debug.Log("Player dead!");
        OnDie?.Invoke();
    }
}