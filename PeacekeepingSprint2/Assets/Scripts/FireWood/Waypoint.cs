using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public List<Transform> waypoints = new List<Transform>();
    private Transform targetWaypoint;
    private int targetWaypointIndex = 0;
    private float minDistance = 0.1f;
    private float lastWaypointIndex;

    public float movementSpeed = 0f;
    private float rotationSpeed = 2.0f;

    public float gatherTime = 20f;
    public bool woodGathered = false;
    public bool missionStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        lastWaypointIndex = waypoints.Count - 1;
        //target waypoint is equal to one in the list
        targetWaypoint = waypoints[targetWaypointIndex];
    }

    // Update is called once per frame
    void Update()
    {
       if(missionStarted == false && Input.GetKeyDown(KeyCode.M))
        {
            missionStarted = true;
            movementSpeed = 4;
        }
        
        
        //make speed based from time.deltatime and rotation speed
        float movementStep = movementSpeed * Time.deltaTime;
        float rotationStep = rotationSpeed * Time.deltaTime;

        //find out how much the player needs to rotate by
        Vector3 directionToTarget = targetWaypoint.position - transform.position;
        Quaternion rotationToTarget = Quaternion.LookRotation(directionToTarget);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotationToTarget, rotationStep);
        
        //check distance between waypoints and moving object
        float distance = Vector3.Distance(transform.position, targetWaypoint.position);
        CheckDistanceToWaypoint(distance);
        //move the player to the waypoint position
        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, movementStep);

        //if (targetWaypointIndex == 9 && woodGathered == false)
       // {
         //   movementSpeed = 0;
         //   gatherTime -= Time.deltaTime;
       // }

        //if (gatherTime <= 0.0f)
        //{
        //    onceWoodGathered();
       // }

        //if (targetWaypointIndex == 17)
        //{
        //    movementSpeed = 0;
       // }
    }

    void CheckDistanceToWaypoint(float currentDistance)
    {
       if(currentDistance <= minDistance)
        {
            //increase the target waypoint index when object is close to the waypoint
            targetWaypointIndex++;
            UpdateTargetWaypoint();
        }
    }

    void UpdateTargetWaypoint()
    {
        //rest back the loop so it keeps going around
        if (targetWaypointIndex > lastWaypointIndex)
        {
            targetWaypointIndex = 0;
        }
        targetWaypoint = waypoints[targetWaypointIndex];
    }

    //void onceWoodGathered()
    //{
      //  woodGathered = true;
     //   movementSpeed = 4f;
     //   gatherTime = 10000000f;
   // }


}
