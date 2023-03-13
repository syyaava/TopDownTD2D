using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public EnemyMover EnemyMover;
    public int DamageToPlayerBase = 1;

    private void Awake()
    {
        if (EnemyMover == null)
            EnemyMover = GetComponent<EnemyMover>();
    }

    public void HandleMoveBody(Vector2 movementVector)
    {
        EnemyMover.Move(movementVector);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var playerBase = collision.GetComponent<PlayerBase>();
        if (playerBase == null)
            return;
        Debug.Log(playerBase == null);

        playerBase.GetComponent<Damageble>().Hit(DamageToPlayerBase);
        var damageble = GetComponent<Damageble>();

        if(damageble != null)
            damageble.Hit(damageble.MaxHealth);
    }
}
