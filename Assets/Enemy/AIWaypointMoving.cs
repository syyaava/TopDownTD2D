using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyController))]
public class AIWaypointMoving : MonoBehaviour
{    
    [Range(0.1f, 1f)]
    public float ArriveDistance = 1f;
    public float WaitTime = 0.5f;
    public int PathNumber = 0;
        
    [Range(0.01f, 1f)]
    [SerializeField]
    private float dotProductRotate = 0.999f;
    [SerializeField]
    private Vector2 currentPatrolTarget = Vector2.zero;

    private bool isInitialized = false;
    private int currentIndex = -1;
    private EnemyController controller;
    private PatrolPath waypoints;
    private bool isWaiting = false;

    private void Start()
    {
        waypoints = SceneController.Instance.Paths[PathNumber];
        controller = GetComponent<EnemyController>();
    }


    // Update is called once per frame
    private void Update()
    {
        if (!isWaiting)
        {
            if (waypoints.Length < 2)
                return;

            if (!isInitialized)
            {
                var currentPathPoint = waypoints.GetClosestPathPoint(transform.position);
                currentIndex = currentPathPoint.Index;
                currentPatrolTarget = currentPathPoint.Position;
                isInitialized = true;
            }

            WaitOnWaypoint();

            Rotate(controller);
        }
    }

    private void WaitOnWaypoint()
    {
        if (Vector2.Distance(transform.position, currentPatrolTarget) < ArriveDistance)
        {
            isWaiting = true;
            StartCoroutine(WaitCoroutine());
            return;
        }
    }

    private IEnumerator WaitCoroutine()
    {
        yield return new WaitForSeconds(WaitTime);
        var nextPathPoint = waypoints.GetNextPathPoint(currentIndex);
        currentPatrolTarget = nextPathPoint.Position;
        currentIndex = nextPathPoint.Index;
        isWaiting = false;
    }

    private void Rotate(EnemyController enemy)
    {
        var directionToGo = currentPatrolTarget - (Vector2)(gameObject.transform.position);
        var dotProduct = Vector2.Dot(gameObject.transform.up, directionToGo.normalized);

        if (dotProduct < dotProductRotate)
        {
            var crossProduct = Vector3.Cross(gameObject.transform.up, directionToGo.normalized);
            var rotationResult = crossProduct.z >= 0 ? -1 : 1;
            enemy.HandleMoveBody(new Vector2(rotationResult, 1));
        }
        else
        {
            enemy.HandleMoveBody(Vector2.up);
        }
    }
}
