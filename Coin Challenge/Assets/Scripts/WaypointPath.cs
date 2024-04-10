using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointPath : MonoBehaviour
{
    private Transform[] wayPoints;

    private void Awake()
    {
        wayPoints = new Transform[transform.childCount];

        int index = 0;
        foreach (Transform child in transform)
        {
            wayPoints[index] = child;
            index++;
        }
    }

    public Transform GetWaypoint(int waypointIndex)
    {
        return transform.GetChild(waypointIndex);
    }

    public int GetNextWaypointIndex(int currentWaypointIndex)
    {
        int nextWaypointIndex = currentWaypointIndex + 1;

        if (nextWaypointIndex == transform.childCount)
        {
            nextWaypointIndex = 0;
        }

        return nextWaypointIndex;
    }

    public Vector3 GetRandWayPoint()
    {
        int randIndex = Random.Range(0, wayPoints.Length);

        return wayPoints[randIndex].position;
    }
}
