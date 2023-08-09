using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBox : MonoBehaviour {

    public Vector3[] waypoints = new Vector3[5];
    public float speed;

    private Vector3 currentWaypoint;
    private int currentWaypointIndex;
    private bool directionForward;

    private void Start() {
        directionForward = true;
        transform.position = waypoints[0];
    }

    private void Update() {
        currentWaypoint = waypoints[currentWaypointIndex];
        transform.LookAt(currentWaypoint);
        transform.position = Vector3.MoveTowards(transform.position, currentWaypoint, Time.deltaTime * speed);
        GetNextWaypoint();
    }

    public void GetNextWaypoint() {

        if(transform.position == currentWaypoint) {
            if(directionForward) {
                currentWaypointIndex++;
                if(currentWaypointIndex == waypoints.Length) {
                    directionForward = false;
                    currentWaypointIndex--;
                }
            } else {
                currentWaypointIndex--;
                if (currentWaypointIndex < 0) {
                    directionForward = true;
                    currentWaypointIndex++;
                }
            }
        } 
    }

}
