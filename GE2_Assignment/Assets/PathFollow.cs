using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollow : SteeringBehaviour
{
    public Path path;
    public bool pathFollowingEnabled = false;
    public float waypointDistance = 3;
    public int currentWaypoint = -1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 PathFollowCalc()
    {
        Vector3 nextWaypoint = path.NextWaypoint();
        if (path.IsLast())
        {   
            if(Vector3.Distance(transform.position, nextWaypoint) < waypointDistance) {
                pathFollowingEnabled = false;
                currentWaypoint++;
            }
            return boid.ArriveForce(nextWaypoint);
        }
        else
        {
            if (Vector3.Distance(transform.position, nextWaypoint) < waypointDistance)
            {
                path.AdvanceToNext();
                currentWaypoint = path.next; 
            }
            return boid.SeekForce(nextWaypoint);
        }
    }

    public override Vector3 Calculate()
    {
        Vector3 f = Vector3.zero;

        if (pathFollowingEnabled)
        {
            f += PathFollowCalc();
        }

        return f;
    }
}
