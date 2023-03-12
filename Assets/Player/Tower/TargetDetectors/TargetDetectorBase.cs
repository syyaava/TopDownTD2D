using UnityEngine;

public abstract class TargetDetectorBase : MonoBehaviour
{
    public LayerMask EnemyLayerMask;
    protected Transform[] targets;
    public abstract Transform[] DetectTargets();
}
