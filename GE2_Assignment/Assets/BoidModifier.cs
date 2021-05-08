using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidModifier : MonoBehaviour
{
    Boid boid;
    PathFollow pathFollow;

    public int changeMaxSpeedAtWaypoint = -1;
    public int desiredMaxSpeed = -1;
    public int changeMaxForceAtWaypoint = -1;
    public int desiredMaxForce = -1;
    // Start is called before the first frame update
    void Start()
    {

    }

    void Awake()
    {
        boid = GetComponent<Boid>();
        pathFollow = GetComponent<PathFollow>();
    }

    // Update is called once per frame
    void Update()
    {
        if (boid != null && pathFollow != null)
        {
            if (pathFollow.currentWaypoint > -1)
            {
                if (pathFollow.currentWaypoint == changeMaxForceAtWaypoint)
                {
                    boid.maxForce = Mathf.Lerp(boid.maxForce, desiredMaxForce, 1f * Time.deltaTime);
                }

                if (pathFollow.currentWaypoint == changeMaxSpeedAtWaypoint)
                {
                    boid.maxSpeed = Mathf.Lerp(boid.maxSpeed, desiredMaxSpeed, 1f * Time.deltaTime);
                }
            }
        }
    }
}
