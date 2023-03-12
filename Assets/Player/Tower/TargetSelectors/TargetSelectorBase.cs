using UnityEngine;

public abstract class TargetSelectorBase : MonoBehaviour
{       
    public abstract Transform SelectTarget(TargetDetectorBase detector);
}