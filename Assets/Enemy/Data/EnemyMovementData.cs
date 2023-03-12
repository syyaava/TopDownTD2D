using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyMovementData", menuName = "Data/EnemyMovementData")]
public class EnemyMovementData : ScriptableObject
{
    public float MaxSpeed = 10f;
    public float RotationSpeed = 100f;
    public float Acceleration = 70f;
    public float Deacceleration = 50f;
}