using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(TargetSelectorBase))]
[RequireComponent(typeof(TargetDetectorBase))]
public class Tower : MonoBehaviour //TODO: Пересмотреть получение детектора и селектора целей.
{
    public Bullet BulletPrefab;
    public float ReloadSecs = 2f;
    public float ShootDistance = 5.0f;
    public TargetSelectorBase TargetSelector;
    public TargetDetectorBase TargetDetector;
    public Transform Barret;

    private Transform currentTarget;    
    private bool canShoot = true;

    private void Start()
    {
        if(TargetSelector == null)
            TargetSelector = GetComponent<TargetSelectorBase>();
        if(TargetDetector == null)
            TargetDetector = GetComponent<TargetDetectorBase>();
    }

    private void Update()
    {
        if (currentTarget == null)
            SeekTarget();

        if (currentTarget != null && canShoot)
            Shoot();

        if (currentTarget != null && Vector2.Distance(transform.position, currentTarget.position) > ShootDistance)
            currentTarget = null;
    }

    private void SeekTarget()
    {
        currentTarget = TargetSelector.SelectTarget(TargetDetector);
    }

    private void Shoot()
    {
        var bullet = Instantiate(BulletPrefab, Barret.position, Quaternion.identity, Barret);
        bullet.Target = currentTarget;
        StartCoroutine(Reload());
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, ShootDistance);
    }

    private IEnumerator Reload()
    {
        canShoot = false;
        yield return new WaitForSeconds(ReloadSecs);
        canShoot = true;
    }
}
