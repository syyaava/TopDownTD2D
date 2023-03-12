using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PatrolPath : MonoBehaviour
{
    public List<Transform> Waypoints = new List<Transform>();
    public int Length { get => Waypoints.Count; }

    [Header("Gizmos parametrs")]
    public Color PointsColor = Color.blue;
    public float PointSize = 0.3f;
    public Color LineColor = Color.magenta;

    private void Start()
    {
        PGFLogger.Log($"Enemy path: {WaypointsToString()}");
    }

    public struct PathPoint
    {
        public int Index;
        public Vector2 Position;
    }

    public PathPoint GetClosestPathPoint(Vector2 tankPosition)
    {
        var minDistance = float.MaxValue;
        var index = -1;
        for(var i = 0; i < Waypoints.Count; i++)
        {
            var tempDistance = Vector2.Distance(tankPosition, Waypoints[i].position);
            if(tempDistance < minDistance)
            {
                minDistance = tempDistance;
                index = i;
            }
        }

        return new PathPoint { Index = index, Position = Waypoints[index].position };
    }

    public PathPoint GetNextPathPoint(int index)
    {
        var newIndex = index + 1 >= Waypoints.Count ? 0 : index + 1;
        return new PathPoint { Index = newIndex, Position = Waypoints[newIndex].position };
    }

    private void OnDrawGizmos()
    {
        if(Waypoints.Count == 0)
            return;

        for(var i = Waypoints.Count - 1; i >= 0; i--)
        {
            var point = Waypoints[i];
            if (i == -1 || point == null)
                return;

            DrawPatrolPoint(point.position);

            if (Waypoints.Count == 1 || i == 0)
                return;

            DrawPatrolLine(i, point.position);
        }
    }

    private void DrawPatrolPoint(Vector2 position)
    {
        Gizmos.color = PointsColor;
        Gizmos.DrawSphere(position, PointSize);
    }

    private void DrawPatrolLine(int i, Vector2 position)
    {
        Gizmos.color = LineColor;
        Gizmos.DrawLine(position, Waypoints[i - 1].position);

        if (Waypoints.Count > 2 && i == Waypoints.Count - 1)
            Gizmos.DrawLine(position, Waypoints[0].position);
    }

    private string WaypointsToString()
    {
        var str = "(";
        str += string.Join("); (", Waypoints);
        str += ")";
        return str;
    }    
}
