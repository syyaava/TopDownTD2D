using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public EnemyMovementData MovementData;
    public float CurrentSpeed = 0f;
    public float CurrentForewardDirection = 1f;

    private Vector2 movementVector;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb2d.velocity = (Vector2)transform.up * CurrentSpeed * CurrentForewardDirection * Time.fixedDeltaTime;
        float angleZ = -movementVector.x * MovementData.RotationSpeed * Time.fixedDeltaTime;
        rb2d.MoveRotation(transform.rotation * Quaternion.Euler(0f, 0f, angleZ));
    }

    public void Move(Vector2 movementVector)
    {
        this.movementVector = movementVector;
        CalculateSpeed(movementVector);
        if (movementVector.y > 0f)
            CurrentForewardDirection = 1f;
        else if (movementVector.y < 0)
            CurrentForewardDirection = -1f;
    }

    private void CalculateSpeed(Vector2 movementVector)
    {
        if (Mathf.Abs(movementVector.y) > 0)
            CurrentSpeed += MovementData.Acceleration * Time.deltaTime;
        else
            CurrentSpeed -= MovementData.Deacceleration * Time.deltaTime;

        CurrentSpeed = Mathf.Clamp(CurrentSpeed, 0f, MovementData.MaxSpeed);
    }
}
