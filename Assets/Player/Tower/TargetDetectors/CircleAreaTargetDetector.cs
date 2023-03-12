using System.Linq;
using UnityEngine;

public class CircleAreaTargetDetector : TargetDetectorBase
{
    private Tower tower;

    private void Start()
    {
        tower = GetComponent<Tower>();
    }

    public override Transform[] DetectTargets()
    {
        targets = Physics2D.OverlapCircleAll(transform.position, tower.ShootDistance, EnemyLayerMask).Select(x => x.transform).ToArray();
        return targets;
    }
}