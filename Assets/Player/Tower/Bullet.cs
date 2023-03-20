using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public BulletData BulletStats;
    public float SelfDestructionDelaySecs = 10f;
    public Transform Target;
    public Animator BulletAnimator;

    protected Rigidbody2D rb2d;
    protected DestroyUtil destroyUtil;
    protected bool isAlive = true;

    protected void Start()
    {
        destroyUtil = GetComponent<DestroyUtil>();
        rb2d = GetComponent<Rigidbody2D>();
        StartCoroutine(SelfDestruct());
    }

    protected void Update()
    {
        if(isAlive) Movement();
        else rb2d.velocity = Vector3.zero;
    }

    protected virtual void Movement()
    {
        if (Target != null)
        {
            var directionToGo = (Vector2)Target.position - (Vector2)(gameObject.transform.position);

            var crossProduct = Vector3.Cross(gameObject.transform.up, directionToGo.normalized);
            var rotationResult = crossProduct.z >= 0 ? -1 : 1;
            var movementVector = new Vector2(rotationResult, 1);

            rb2d.velocity = (Vector2)transform.up * BulletStats.Speed * Time.deltaTime;
            float angleZ = -movementVector.x * BulletStats.RotationSpeed * Time.deltaTime;
            rb2d.MoveRotation(transform.rotation * Quaternion.Euler(0f, 0f, angleZ));
        }
        else
            Destroy(gameObject);
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
