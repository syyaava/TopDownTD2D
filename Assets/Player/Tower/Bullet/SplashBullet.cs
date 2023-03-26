using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SplashBullet : Bullet
{
    public float SplashRadius = 0.5f;
    public LayerMask EnemyLayer;

    protected override void SetDamage(Collider2D collision, Damageble enemy)
    {
        isAlive = false;
        var damagebles = Physics2D.OverlapCircleAll(collision.transform.position, SplashRadius, EnemyLayer).Select(x => x.GetComponent<Damageble>())
            .Where(x => x != null && x.tag != PlayerBase.PlayerBaseTag);
        foreach (var damageble in damagebles)
            damageble.Hit(BulletStats.Damage);

        StartCoroutine(DestroyOnImpact());
    }
}
