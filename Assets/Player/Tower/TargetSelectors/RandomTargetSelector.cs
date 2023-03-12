using UnityEngine;

public class RandomTargetSelector : TargetSelectorBase
{
    public override Transform SelectTarget(TargetDetectorBase detector)
    {
        var potentialTargets = detector.DetectTargets();
        if(potentialTargets == null || potentialTargets.Length == 0) return null;

        return potentialTargets[Random.Range(0, potentialTargets.Length)];
    }

    public override string ToString()
    {
        return "Random target selector";
    }
}
