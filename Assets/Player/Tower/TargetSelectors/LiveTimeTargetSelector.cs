using System;
using System.Linq;
using UnityEngine;

public class LiveTimeTargetSelector : TargetSelectorBase
{
    public override Transform SelectTarget(TargetDetectorBase detector)
    {
        var targets = detector.DetectTargets();
        if(targets == null || targets.Length <= 0) return null;

        var enemyControllers = targets.Select(x => x.GetComponent<EnemyController>());
        Transform maxLiveTimeTarget = null;
        var maxLiveTime = float.MinValue;

        foreach(var controller in enemyControllers)
        {
            if (maxLiveTime < controller.LiveTime)
            {
                maxLiveTime = controller.LiveTime;
                maxLiveTimeTarget = controller.transform;
            }
        }
        return maxLiveTimeTarget;
    }
}
