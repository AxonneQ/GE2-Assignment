using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpLeave : MonoBehaviour
{
    public GameObject ship;
    public float maxSpeedAfterLeave;
    public float maxVelocityAfterLeave;
    public float maxForceAfterLeave;
    public int leaveAtWaypoint;
    public AudioClip sound;

    private AudioSource[] audioSources;
    // Start is called before the first frame update
    void Start()
    {
        audioSources = GetComponents<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Boid ship = this.ship.GetComponent<Boid>();
        PathFollow shipPath = this.ship.GetComponent<PathFollow>();

        if(shipPath.currentWaypoint == leaveAtWaypoint) {
            ship.maxSpeed = maxSpeedAfterLeave;
            ship.maxForce = maxForceAfterLeave;
            ship.force = ship.force.normalized * maxForceAfterLeave;
            ship.velocity = ship.velocity.normalized * maxVelocityAfterLeave;
            audioSources[1].PlayOneShot(sound);
            shipPath.currentWaypoint = 0;
        }
    }
}
