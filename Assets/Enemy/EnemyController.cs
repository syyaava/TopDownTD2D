using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public EnemyMover EnemyMover;

    private void Awake()
    {
        if (EnemyMover == null)
            EnemyMover = GetComponent<EnemyMover>();
    }

    public void HandleMoveBody(Vector2 movementVector)
    {
        EnemyMover.Move(movementVector);
    }
}
