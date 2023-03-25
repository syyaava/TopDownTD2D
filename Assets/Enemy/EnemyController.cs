using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public EnemyMover EnemyMover;
    public int DamageToPlayerBase = 1;
    public float LiveTime = 0f;
    public float LiveTimeStep = 0.5f;

    private void Awake()
    {
        if (EnemyMover == null)
            EnemyMover = GetComponent<EnemyMover>();
        StartCoroutine(AddLiveTime());
    }

    public void HandleMoveBody(Vector2 movementVector)
    {
        EnemyMover.Move(movementVector);
    }

    public void IncreaseCountOfPlayerFrags()
    {
        PlayerResourceController.FragsCount++;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var playerBase = collision.GetComponent<PlayerBase>();
        if (playerBase == null)
            return;

        playerBase.GetComponent<Damageble>().Hit(DamageToPlayerBase);
        var damageble = GetComponent<Damageble>();

        if(damageble != null)
            damageble.Hit(damageble.MaxHealth);
    }

    private IEnumerator AddLiveTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            LiveTime += LiveTimeStep;
        }
    }
}
