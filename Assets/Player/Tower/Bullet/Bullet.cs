using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BulletMover))]
public class Bullet : MonoBehaviour //TODO: Перенести нанесение урона в отдельный класс
{
    public BulletData BulletStats;
    public float SelfDestructionDelaySecs = 10f;
    public Transform Target;
    public Animator BulletAnimator;

    protected Rigidbody2D rb2d;
    protected DestroyUtil destroyUtil;
    protected bool isAlive = true;
    protected BulletMover bulletMover;

    protected void Start()
    {
        destroyUtil = GetComponent<DestroyUtil>();
        rb2d = GetComponent<Rigidbody2D>();
        bulletMover = GetComponent<BulletMover>();
        bulletMover.Initialize(Target, rb2d, BulletStats);
        StartCoroutine(SelfDestruct());
    }

    protected void Update()
    {
        if(isAlive) bulletMover.Movement();
        else rb2d.velocity = Vector3.zero;
    }

    protected IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(SelfDestructionDelaySecs);
        Destroy(gameObject);
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        var damagble = collision.transform.GetComponent<Damageble>();
        if (damagble == null || damagble.tag == PlayerBase.PlayerBaseTag) return;

        SetDamage(collision, damagble);
    }

    protected virtual void SetDamage(Collider2D collision, Damageble damagble)
    {
        damagble.Hit(BulletStats.Damage);
        isAlive = false;
        StartCoroutine(DestroyOnImpact());
    }

    protected IEnumerator DestroyOnImpact()
    {
        BulletAnimator.SetBool("isImpact", true);
        yield return new WaitForSeconds(0.5f);
        destroyUtil.DestroyHelper();
    }

    public void AddBulletStatsBonus(BulletData stats)
    {
        BulletStats = BulletStats + stats;
    }
}
