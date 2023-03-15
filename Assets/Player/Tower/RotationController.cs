using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationController : MonoBehaviour
{
    public float TowerRotationSpeed = 2560f;
    public void LookAt(Vector2 position)
    {
        var direction = (Vector3)position - transform.position;
        var desiredAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        var rotationStep = TowerRotationSpeed * Time.deltaTime;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0f, 0f, desiredAngle - 90f), rotationStep);
    }
}
