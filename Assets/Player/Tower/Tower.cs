using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(TargetSelectorBase))]
[RequireComponent(typeof(TargetDetectorBase))]
public class Tower : MonoBehaviour //TODO: Пересмотреть получение детектора и селектора целей.
{
    public TowerData TowerData;
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
        PGFLogger.Log($"Tower was placed. " + this.ToString());
    }

    private void Update()
    {
        if (currentTarget == null)
            SeekTarget();

        if (currentTarget != null && canShoot)
            Shoot();

        if (currentTarget != null && Vector2.Distance(transform.position, currentTarget.position) > TowerData.ShootDistance)
            currentTarget = null;
    }

    private void SeekTarget()
    {
        currentTarget = TargetSelector.SelectTarget(TargetDetector);
    }

    private void Shoot()
    {
        var bullet = Instantiate(TowerData.BulletPrefab, Barret.position, Quaternion.identity, Barret);
        bullet.Target = currentTarget;
        StartCoroutine(Reload());
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, TowerData.ShootDistance);
    }

    private IEnumerator Reload()
    {
        canShoot = false;
        yield return new WaitForSeconds(TowerData.ReloadSecs);
        canShoot = true;
    }

    public override string ToString()
    {
        return $"Name: {gameObject.name}. Bullet: {TowerData.BulletPrefab.name}. Shoot distance: {TowerData.ShootDistance}. Reload: {TowerData.ReloadSecs}." +
            $"Target detector: {TargetDetector}. Target selector: {TargetSelector}.";
    }
}
