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
    public Animator TowerAnimator;

    private Transform currentTarget;
    private RotationController rotationController;
    private bool canShoot = true;

    private void Start()
    {
        if(TargetSelector == null)
            TargetSelector = GetComponent<TargetSelectorBase>();
        if(TargetDetector == null)
            TargetDetector = GetComponent<TargetDetectorBase>();
        if(rotationController  == null)
            rotationController = GetComponentInChildren<RotationController>();
    }

    private void Update()
    {
        if (currentTarget == null)
            SeekTarget();

        if (currentTarget != null)
        {
            rotationController.LookAt(currentTarget.position);
            if(canShoot)
                Shoot();
        }            

        if (currentTarget != null && Vector2.Distance(transform.position, currentTarget.position) > TowerData.ShootDistance)
            currentTarget = null;
    }

    private void SeekTarget()
    {
        currentTarget = TargetSelector.SelectTarget(TargetDetector);
    }

    private void Shoot()
    {
        TowerAnimator.SetBool("isShoot", true);
        var bullet = Instantiate(TowerData.BulletPrefabs[TowerData.Level - 1], Barret.position, Barret.rotation);
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
        TowerAnimator.SetBool("isShoot", false);
        canShoot = true;
    }

    public override string ToString()
    {
        return $"Name: {gameObject.name}. Bullet: {TowerData.BulletPrefabs[TowerData.Level - 1].name}. " +
            $"Shoot distance: {TowerData.ShootDistance}. Reload: {TowerData.ReloadSecs}." +
            $"Target detector: {TargetDetector}. Target selector: {TargetSelector}.";
    }
}
